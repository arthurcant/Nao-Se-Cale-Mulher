using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Context;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository.Implementations;

namespace API_SITE_Mulher.Business.Implementations
{
    public class PosteresBusinessImplementation : IPosteresBusiness
    {
        private readonly ILogger<Poster> _logger;
        private IRepository<tb_poster> _repository;

        public PosteresBusinessImplementation(ILogger<Poster> logger, IRepository<tb_poster> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public Poster Create(Poster poster)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Poster> FindPostersByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public PagedSearchVO<Poster> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            throw new NotImplementedException();
        }

        public Poster Update(Poster poster)
        {
            throw new NotImplementedException();
        }
    }
}
