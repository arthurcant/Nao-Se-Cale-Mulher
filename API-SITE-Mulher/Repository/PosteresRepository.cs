using API_SITE_Mulher.Model.Context;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;
using System.Linq;

namespace API_SITE_Mulher.Repository
{
    public class PosteresRepository : GenericRepository<tb_poster> , IPosteresRepository
    {
        protected MySQLContext context;
        public PosteresRepository(MySQLContext context) : base(context)
        {
        }

        public List<tb_poster> FindPostersByTitle(string title)
        {

            var posterExact = context.tb_posters.Where(p => p.Titulo.Equals(title)).ToList();

            if (posterExact.Count == 1)
            {
                return posterExact;
            }

           return context.tb_posters.Where(p => p.Titulo.Contains(title)).ToList();
        }

    }
}
