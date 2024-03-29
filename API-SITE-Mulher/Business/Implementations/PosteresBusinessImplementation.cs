﻿using API_SITE_Mulher.Data.Converter.Implementations;
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
        private ICategoriaRepository _categoriaRepository;
        private readonly UsuarioConverter _converter;
        private readonly PosterConverter _posterConverter;
        private FillingEntity _fillingEntity;

        public PosteresBusinessImplementation(
            ILogger<Poster> logger, 
            IRepository<tb_poster> repository,
            IPosteresRepository posteresRepository,
            IUsersRepository usersRepository,
            FillingEntity fillingEntity,
            ICategoriaRepository categoriaRepository)
        {
            _logger = logger;
            _repository = repository;
            _fillingEntity = fillingEntity;
            _usersRepository = usersRepository;
            _posteresRepository = posteresRepository;
            _converter = new UsuarioConverter();
            _posterConverter = new PosterConverter(_usersRepository);
            _categoriaRepository = categoriaRepository;
        }

        public tb_poster Create(PosterVO posterRegisterVO, string email)
        {
            tb_poster tbPoster = new tb_poster();
            tbPoster.UrlImagePoster = posterRegisterVO.UrlImagePoster;
            tbPoster.Titulo = posterRegisterVO.Titulo;
            tbPoster.Descricao = posterRegisterVO.Descricao;
            tbPoster.Conteudo = posterRegisterVO.Conteudo;
            tbPoster.DataDaPublicacao = DateTime.Now;
            tbPoster.tbUsuarios = _usersRepository.ValidateCredentials(email);
            //tbPoster.id_usuario = tbPoster.tb_usuarioAutor.Id;
            var posterCreated = _posteresRepository.CreatePoster(tbPoster);

            if (posterRegisterVO.Tags is not null)
            {
                tb_categoria_de_posteres categoriaVerificada = new tb_categoria_de_posteres();
                List<tb_categoria_de_posteres> tb_Categoria = new List<tb_categoria_de_posteres>();
                foreach (var item in posterRegisterVO.Tags)
                {
                    categoriaVerificada = _categoriaRepository.foundCategoriaById(item);

                    if (categoriaVerificada != null)
                        tb_Categoria.Add(categoriaVerificada);
                }

                posterCreated.tbCategoriaDePosteres = tb_Categoria;

                posterCreated = _repository.Update(posterCreated);
            }

            return posterCreated;
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }

        public PagedSearchVO<Poster> FindWithPagedSearch(string sortDirection, int pageSize, int page, tb_usuario tbUsuario, string title)
        {
            var sort = (!string.IsNullOrEmpty(sortDirection) && !sortDirection.Equals("asc")) ? "desc" : "asc";

            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from tb_poster p where 1 = 1 ";

            if (!string.IsNullOrEmpty(title)) query += $" and p.titulo like '%{title}%' ";
            query += $"order by p.titulo {sort} limit {size} offset {offset} ";

            string countQuery = @"select count(*) from tb_poster p where 1 = 1 ";
            if (!string.IsNullOrEmpty(title)) countQuery += $" and p.titulo like '%{title}%' ";

            var posteres = _posteresRepository.FindWithPagedSearchPosteres(query);
            int totalResult = _repository.GetCount(countQuery);

            return new PagedSearchVO<Poster>
            {
                CurrentPage = page,
                List = _posterConverter.Parse(posteres, tbUsuario),
                PageSize= pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResult
            };
        }
        public bool UpdateImageUrlPoster(int id, ImageUrlVO imageUrl)
        {
            var poster = _posteresRepository.FindById(id);

            if (poster is null) return false;

            poster.UrlImagePoster = imageUrl.UrlImage;

            var posterUpdated = _posteresRepository.Update(poster);

            if (posterUpdated is null) return false;

            return true;
        }

        public Poster Update(Poster poster, tb_usuario tbUsuario)
        {
            var tbPoster = _posterConverter.Parse(poster, tbUsuario);
            var posterModel = _posterConverter.Parse(_repository.Update(tbPoster), tbUsuario);

            return posterModel;
        }
    }
}