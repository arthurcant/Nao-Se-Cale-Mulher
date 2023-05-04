using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;

namespace API_SITE_Mulher.Repository
{
    public interface ICategoriaRepository : IRepository<tb_categoria_de_posteres>
    {
        bool AddCategoriasParaPoster(int idPoster, int idCategoria);
        List<tb_categoria_de_posteres> FindWithPagedSearchCategorias(string query);
        IQueryable<ICollection<tb_poster>?> GetPosteresByIdCategoria(int id);

        tb_categoria_de_posteres foundCategoriaById(int id);
    }
}
