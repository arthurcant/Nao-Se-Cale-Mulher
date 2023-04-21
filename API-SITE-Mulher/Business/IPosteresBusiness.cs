using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Business
{
    public interface IPosteresBusiness
    {
        tb_poster Create(PosterRegisterVO poster, string email);
        PagedSearchVO<Poster> FindWithPagedSearch(string sortDirection, int pageSize, int page, string title = null);
        Poster Update(Poster poster);
        void DeleteById(long id);
    }
}
