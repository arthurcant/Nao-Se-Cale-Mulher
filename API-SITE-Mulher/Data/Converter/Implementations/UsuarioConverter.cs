using API_SITE_Mulher.Data.Converter.Contract;
using API_SITE_Mulher.Enum;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Data.Converter.Implementations
{
    public class UsuarioConverter : IParser<tb_usuario, Usuario>, IParser<Usuario, tb_usuario>
    {
        public UsuarioConverter()
        {
        }

        public Usuario Parse(tb_usuario origin)
        {
            if (origin == null) return null;

            return new Usuario
            {
                Id = origin.Id,
                NomeCompleto = origin.NomeCompleto,
                Email = origin.Email,
                Senha = origin.Senha,
                Role = (Roles)origin.Role,
                RefreshToken = origin.RefreshToken,
                RefreshTokenExpiryTime = origin.RefreshTokenExpiryTime
            };
        }

        public tb_usuario Parse(Usuario origin)
        {
            if (origin == null) return null;

            return new tb_usuario
            {
                Id = origin.Id,
                NomeCompleto = origin.NomeCompleto,
                Email = origin.Email,
                Senha = origin.Senha,
                Role = (int)origin.Role,
                RefreshToken = origin.RefreshToken,
                RefreshTokenExpiryTime = origin.RefreshTokenExpiryTime
            };
        }   

        public List<Usuario> Parse(List<tb_usuario> origin)
        {
            if (origin == null) return null;
            
            return origin.Select(item => Parse(item)).ToList();

        }


        public List<tb_usuario> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
