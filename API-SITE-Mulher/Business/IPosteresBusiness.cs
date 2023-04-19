using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;

namespace API_SITE_Mulher.Business
{
    public interface IPosteresBusiness
    {
        Poster Create(PosterRegisterVO poster);
        PagedSearchVO<Poster> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        Poster Update(Poster poster);
        void DeleteById(long id);
        List<Poster> FindPostersByTitle(string title);
    }
}
