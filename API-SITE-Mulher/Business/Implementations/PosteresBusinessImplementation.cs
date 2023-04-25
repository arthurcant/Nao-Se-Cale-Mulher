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
        private IPosteresRepository _posteresRepository;
        private readonly UsuarioConverter _converter;
        private readonly PosterConverter _posterConverter;
        private FillingEntity _fillingEntity;

        public PosteresBusinessImplementation(
            ILogger<Poster> logger, 
            IRepository<tb_poster> repository,
            IPosteresRepository posteresRepository,
            IUsersRepository usersRepository,
            FillingEntity fillingEntity)
        {
            _logger = logger;
            _repository = repository;
            _fillingEntity = fillingEntity;
            _usersRepository = usersRepository;
            _posteresRepository = posteresRepository;
            _converter = new UsuarioConverter();
            _posterConverter = new PosterConverter();
        }

        public tb_poster Create(PosterRegisterVO posterRegisterVO, string email)
        {
            tb_poster tbPoster = new tb_poster();
            tbPoster.Titulo = posterRegisterVO.Titulo;
            tbPoster.Descricao = posterRegisterVO.Descricao;
            tbPoster.Conteudo = posterRegisterVO.Conteudo;
            tbPoster.DataDaPublicacao = DateTime.Now;
            tbPoster.Autor = _usersRepository.ValidateCredentials(email);
            tbPoster.AutorId = tbPoster.Autor.Id;
            var posterCreated = _posteresRepository.CreatePoster(tbPoster);


            tbPoster.tb_Detalhes_Do_Poster = new tb_detalhes_do_poster();
            tbPoster.tb_Detalhes_Do_Poster.tb_Categoria_De_Posteres = new List<tb_categoria_de_posteres>();

            var tbCategorias = new tb_categoria_de_posteres();
            foreach (var item in posterRegisterVO.Tags)
            {
                tbCategorias.Id = item.Id;
                tbCategorias.NomeCategoria = item.NomeCategoria;
                tbCategorias.NomeTag = item.NomeTag;

                tbPoster.tb_Detalhes_Do_Poster.tb_Categoria_De_Posteres.Add(tbCategorias);
            }

            return posterCreated;
        }

        public void DeleteById(long id)
        {
            _repository.DeleteById(id);
        }

        public PagedSearchVO<Poster> FindWithPagedSearch(string sortDirection, int pageSize, int page, string title = null)
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