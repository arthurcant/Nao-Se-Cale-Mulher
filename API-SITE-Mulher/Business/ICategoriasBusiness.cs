using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;

namespace API_SITE_Mulher.Business
{
    public interface ICategoriasBusiness
    {
        CategoriasDePosters Create(CategoriasDePosters categoriasDePosters);
        PagedSearchVO<CategoriasDePosters> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
        CategoriasDePosters Update(CategoriasDePosters categoriasDePosters);
        bool AddCategoriasParaPoster(int idPoster, int idCategoria);
        List<Poster> GetPosteresByIdCategoria(int id, tb_usuario user);
        void Delete(int id);
    }
}
