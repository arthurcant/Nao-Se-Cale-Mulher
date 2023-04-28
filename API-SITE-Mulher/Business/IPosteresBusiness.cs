using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Business
{
    public interface IPosteresBusiness
    {
        tb_poster Create(PosterVO poster, string email);
        PagedSearchVO<Poster> FindWithPagedSearch(string sortDirection, int pageSize, int page, tb_usuario tbUsuario, string title);
        Poster Update(Poster poster, tb_usuario tbUsuario);
        void DeleteById(long id);
    }
}
