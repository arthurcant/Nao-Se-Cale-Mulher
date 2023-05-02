using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;

namespace API_SITE_Mulher.Repository
{
    public interface ICategoriaRepository : IRepository<tb_categoria_de_posteres>
    {
        bool AddCategoriasParaPoster(int idPoster, IdsCategoria idsCategoria);
        List<tb_categoria_de_posteres> FindWithPagedSearchCategorias(string query);

        tb_categoria_de_posteres foundCategoriaById(int id);
    }
}
