using API_SITE_Mulher.Model.Context;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API_SITE_Mulher.Repository
{
    public class PosteresRepository : GenericRepository<tb_poster>, IPosteresRepository
    {

        public PosteresRepository(MySQLContext context) : base(context) { }

        public tb_poster CreatePoster(tb_poster poster)
        {
            if (poster is null) return null;

            _context.tb_posters.Add(poster);
            _context.SaveChanges();
            return poster;
        }

        public List<tb_poster> FindPostersByTitle(string title)
        {

            var posterExact = _context.tb_posters.Where(p => p.Titulo.Equals(title)).ToList();

            if (posterExact.Count == 1)
            {
                return posterExact;
            }

           return _context.tb_posters.Where(p => p.Titulo.Contains(title)).ToList();
        }

        public List<tb_poster> FindWithPagedSearchPosteres(string query)
        {
            return _context.tb_posters.FromSqlRaw(query).Include(p => p.tbCategoriaDePosteres).ToList();
        }
    }
}
