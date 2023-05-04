using API_SITE_Mulher.Data.Converter.Implementations;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Repository.Implementations;

namespace API_SITE_Mulher.Business.Implementations
{
    public class CategoriasBusinessImplementation : ICategoriasBusiness
    {
        private readonly CategoriaConverter _categoriaConverter;
        private readonly PosterConverter _posterConverter;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IRepository<tb_categoria_de_posteres> _repository;

        public CategoriasBusinessImplementation(
            CategoriaConverter categoriaConverter,
            ICategoriaRepository categoriaRepository,
            PosterConverter posterConverter,
            IRepository<tb_categoria_de_posteres> repository)
        {
            _categoriaConverter = categoriaConverter;
            _repository = repository;
            _categoriaRepository = categoriaRepository;
            _posterConverter = posterConverter;
        }

        public CategoriasDePosters Create(CategoriasDePosters categoriasDePosters)
        {
            var tbCategoriasDePosters = _categoriaConverter.Parse(categoriasDePosters);
            tbCategoriasDePosters = _repository.Create(tbCategoriasDePosters);
            var categoriaModel = _categoriaConverter.Parse(tbCategoriasDePosters);
            return categoriaModel;
        }

        public PagedSearchVO<CategoriasDePosters> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrEmpty(sortDirection) && !sortDirection.Equals("desc")) ? "asc" : "desc";

            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from tb_categoria_de_posteres c where 1 = 1 ";

            if (!string.IsNullOrEmpty(name)) query += $" and c.name_categoria like '%{name}%' or c.nome_tag like '%{name}%' ";
            query += $"order by c.name_categoria {sort} limit {size} offset {offset} ";

            string countQuery = @"select count(*) from tb_categoria_de_posteres c where 1 = 1 ";
            if (!string.IsNullOrEmpty(name)) countQuery += $" and c.name_categoria like '%{name}%' or c.nome_tag like '%{name}%' ";

            List<tb_categoria_de_posteres> tbCategorias = _repository.FindWithPagedSearch(query);
            int totalResult = _repository.GetCount(countQuery);

            return new PagedSearchVO<CategoriasDePosters>
            {
                CurrentPage = page,
                List = _categoriaConverter.Parse(tbCategorias),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResult
            };
        }

        public CategoriasDePosters Update(CategoriasDePosters categoriasDePosters)
        {
            var tbCategoria = _categoriaConverter.Parse(categoriasDePosters);
            tbCategoria = _repository.Update(tbCategoria);
            var categoriaModel = _categoriaConverter.Parse(tbCategoria);

            return categoriaModel;
        }

        public void Delete(int id)
        {
            _repository.DeleteById(id);
        }

        public bool AddCategoriasParaPoster(int idPoster, int idCategoria)
        {
            var result = _categoriaRepository.AddCategoriasParaPoster(idPoster, idCategoria);
            return result;
        }

        public List<Poster> GetPosteresByIdCategoria(int id, tb_usuario user)
        {
            var listOfListPoteres = _categoriaRepository.GetPosteresByIdCategoria(id);
            var listposteres = listOfListPoteres.SelectMany(p => p).ToList();
            return _posterConverter.Parse(listposteres, user);
        }
    }
}
