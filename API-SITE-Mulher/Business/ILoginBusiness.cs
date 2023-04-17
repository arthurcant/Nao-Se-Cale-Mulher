using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;

namespace API_SITE_Mulher.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO userCredentials);
        TokenVO ValidateCredentials(TokenVO token);
        Usuario RegisterUser(UsuarioRegister user);
        bool RevokeToken(string userName);
    }
}
