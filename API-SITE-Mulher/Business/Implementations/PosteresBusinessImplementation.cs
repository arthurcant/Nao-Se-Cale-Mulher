using API_SITE_Mulher.Data.Converter.Implementations;
using API_SITE_Mulher.Data.FillingEntities;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Context;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Repository.Implementations;

namespace API_SITE_Mulher.Business.Implementations
{
    public class PosteresBusinessImplementation : IPosteresBusiness
    {
        private readonly ILogger<Poster> _logger;
        private IRepository<tb_poster> _repository;
        private IUsersRepository _usersRepository;
        private readonly UsuarioConverter _converter;
        private readonly PosterConverter _posterConverter;
        private FillingEntity _fillingEntity;

        public PosteresBusinessImplementation(
            ILogger<Poster> logger, 
            IRepository<tb_poster> repository,
            IUsersRepository usersRepository,
            FillingEntity fillingEntity)
        {
            _logger = logger;
            _repository = repository;
            _fillingEntity = fillingEntity;
            _usersRepository = usersRepository;
            _converter = new UsuarioConverter();
            _posterConverter = new PosterConverter();
        }

        public tb_poster Create(PosterRegisterVO poster)
        {
            var tbPoster = _fillingEntity.FillingEntityTbPoster(poster);
            var posterCreated = _repository.Create(tbPoster);

            return posterCreated;
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }

        public PagedSearchVO<Poster> FindWithPagedSearch(string title, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrEmpty(sortDirection) && !sortDirection.Equals("asc")) ? "desc" : "asc";

            var size = (pageSize < 1) ? 1 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from tb_poster p where 1 = 1";

            if (!string.IsNullOrEmpty(title)) query += $" and p.titulo like '%{title}%'";
            query += $"order by p.titulo {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from tb_poster p where 1 = 1";
            if (!string.IsNullOrEmpty(title)) countQuery += $" and p.titulo like '%{title}%'";

            var posteres = _repository.FindWithPagedSearch(query);
            int totalResult = _repository.GetCount(countQuery);

            return new PagedSearchVO<Poster>
            {
                CurrentPage = page,
                List = _posterConverter.Parse(posteres),
                PageSize= pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResult
            };
        }

        public Poster Update(Poster poster)
        {
            var tbPoster = _posterConverter.Parse(poster);
            var posterModel = _posterConverter.Parse(_repository.Update(tbPoster));
            return posterModel;
        }
    }
}