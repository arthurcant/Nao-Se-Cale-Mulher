using API_SITE_Mulher.Configuration;
using API_SITE_Mulher.Data.Converter.Implementations;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Enum;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Repository.Implementations;
using API_SITE_Mulher.Services;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Diagnostics;
using System.Security.Claims;

namespace API_SITE_Mulher.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private readonly UsuarioConverter _converter;
        private IUsersRepository _repository;
        private readonly IRepository<tb_usuario> _repositoryUser;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, 
            IUsersRepository repository, 
            IRepository<tb_usuario> repositoryUser, 
            ITokenService tokenService)
        {
            _configuration = configuration;
            _converter = new UsuarioConverter();
            _repository = repository;
            _repositoryUser = repositoryUser;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);

            if (user is null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            DateTime getNow = DateTime.Now;
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(_converter.Parse(user));

            DateTime createDate = DateTime.Now;
            DateTime expiration = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expiration.ToString(DATE_FORMAT),
                accessToken,
                refreshToken);
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var pricipal = _tokenService.GetPrincipalFromExpiredToken(accessToken);

            var email = pricipal.Identity.Name;

            var tb_usuario = _repository.ValidateCredentials(email);

            if (tb_usuario == null || tb_usuario.RefreshToken != refreshToken) return null;

            accessToken = _tokenService.GenerateAccessToken(pricipal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            tb_usuario.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(_converter.Parse(tb_usuario));
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken);
        }
        
        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }

        public Usuario RegisterUser(UsuarioRegister user)
        {
            tb_usuario usuario = new tb_usuario();

            usuario.NomeCompleto = user.NomeCompleto;
            usuario.Senha = user.Senha;
            usuario.Email = user.Email;
            usuario.Apelido = user.Apelido;
            usuario.Role = (int)Roles.Voluntario;

            usuario.RefreshToken = _tokenService.GenerateRefreshToken();
            usuario.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            var usuarioRegistrado = _repositoryUser.Create(usuario);

            if (usuarioRegistrado == null) return null;

            return _converter.Parse(usuario);
        }

    }
}
