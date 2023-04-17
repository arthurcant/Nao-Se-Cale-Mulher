using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Repository
{
    public interface IUsersRepository
    {
        tb_usuario ValidateCredentials(UserVO user);
        tb_usuario ValidateCredentials(string email);
        bool RevokeToken(string email);
        Usuario RefreshUserInfo(Usuario user);
    }
}
