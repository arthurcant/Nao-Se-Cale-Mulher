using API_SITE_Mulher.Model.Context;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;
using Microsoft.EntityFrameworkCore;

namespace API_SITE_Mulher.Repository
{
    public class CategoriaRepository : GenericRepository<tb_categoria_de_posteres>, ICategoriaRepository
    {
        public CategoriaRepository(MySQLContext context) : base(context) { }

        public bool AddCategoriasParaPoster(int idPoster, IdsCategoria idsCategoria)
        {
            var tbPoster = _context.tb_posters.FirstOrDefault(p => p.Id.Equals(idPoster));

            if (tbPoster == null) return false;

            foreach (var ids in idsCategoria.IDsCategoria)
            {
                var tbCategorias = _context.tb_Categoria_De_Posteres.FirstOrDefault(t => t.Id.Equals(ids));
                if (tbCategorias is not null)
                    tbPoster.tbCategoriaDePosteres.Add(tbCategorias);

            }

            try
            {
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public List<tb_categoria_de_posteres> FindWithPagedSearchCategorias(string query)
        {
            return _context.tb_Categoria_De_Posteres.FromSqlRaw(query).ToList();
        }

        public tb_categoria_de_posteres foundCategoriaById(int id) => _context.tb_Categoria_De_Posteres.FirstOrDefault(t => t.Id == id);
    }
}
