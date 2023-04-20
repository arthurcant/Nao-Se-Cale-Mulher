using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Business
{
    public interface IPosteresBusiness
    {
        tb_poster Create(PosterRegisterVO poster);
        PagedSearchVO<Poster> FindWithPagedSearch(string title, string sortDirection, int pageSize, int page);
        Poster Update(Poster poster);
        void DeleteById(long id);
    }
}
