using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;

namespace API_SITE_Mulher.Business
{
    public interface IUsersBusiness
    {
        PagedSearchVO<Usuario> FindWithPagedSearch(string sortDirection, int pageSize, int page, string emailOrNome);
        Usuario ChangePassword(int id, string newPassword);

        Usuario UpdateRoleUser(int id, int role);

        void DeleteById(int id);
    }
}
