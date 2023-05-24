using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    [Authorize("Bearer")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriasBusiness _categoriasBusiness;
        private IUsersRepository _repository;
        private ILogger<CategoriasController> _logger;

        public CategoriasController(ICategoriasBusiness categoriasBusiness,
            ILogger<CategoriasController> logger,
            IUsersRepository repository)
        {
            _categoriasBusiness = categoriasBusiness;
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Retorna os dados das categorias paginados.
        /// </summary>
        /// <param name="sortDirection"> Receber a instrução se os dados vão ser enviados pela ordem asc (ascendente) ou desc (decendente).</param>
        /// <param name="pageSize">Receber o números de elementos que seram enviados por retorno.</param>
        /// <param name="page">Especifica o número da página consultada.</param>
        /// <param name="name">Parametro query opcional cujo recebe o nome do titulo da categoria a ser buscada.</param>
        /// <returns>Retorna um objeto PagedSearchVO.</returns>
        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedSearchVO<CategoriasDePosters>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get(
            [FromQuery] string? name,
            string sortDirection,
            int pageSize,
            int page) 
        {
            var pagedSearchVO = _categoriasBusiness.FindWithPagedSearch(name , sortDirection, pageSize, page);

            if (pagedSearchVO == null) return BadRequest("Invalid Request");

            return Ok(pagedSearchVO);
        }

        /// <summary>
        /// End-point que busca todos os posteres relacionado a uma categoria.
        /// </summary>
        /// <param name="id_categoria"> Id da categoria a ser consultada.</param>
        /// <returns></returns>
        [HttpGet("{id_categoria}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Poster>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetPosteresByIdCategoria(int id_categoria)
        {
            if(id_categoria <= 0) return BadRequest("Invalid Request");

            var tb_Usuario = _repository.ValidateCredentials(User.Identity.Name);

            var posteres = _categoriasBusiness.GetPosteresByIdCategoria(id_categoria, tb_Usuario);

            if (posteres == null) return BadRequest("Invalid Request");

            return Ok(posteres);
        }

        /// <summary>
        /// End-point que registra uma categoria nova.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("registercategoria")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriasDePosters))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateCategoria([FromBody] CategoriasDePosters categoria) { 

            if(categoria is null) return BadRequest("Invalid Request");

            var categoriaCriada = _categoriasBusiness.Create(categoria);

            if (categoriaCriada is null) return BadRequest("Invalid Request");

            return Ok(categoriaCriada);
        }

        /// <summary>
        /// End-point que adiciona uma categoria ao um poster
        /// </summary>
        /// <param name="idPoster"> Id do poster a atualizado.</param>
        /// <param name="idCategoria"> Id da categoria a ser atualizada no poster.</param>
        /// <returns></returns>
        [HttpGet("{idPoster}/{idCategoria}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriasDePosters))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AddCategoriasParaPoster(int idPoster, int idCategoria)
        {
            if(idPoster <= 0 && idCategoria <= 0) return BadRequest("Invalid Request");

            bool result = _categoriasBusiness.AddCategoriasParaPoster(idPoster, idCategoria);

            if (!result) return BadRequest("Invalid Request");

            return Ok(result);
        }

        /// <summary>
        /// End-point que Atualiza uma categoria.
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Retornar o objeto CategoriasDePosters atualizado.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriasDePosters))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateCategoria([FromBody] CategoriasDePosters categoria)
        {
            if (categoria is null) return BadRequest("Invalid Request");

            var categoriaAtualizada = _categoriasBusiness.Update(categoria);

            if (categoriaAtualizada is null) return BadRequest("Invalid Request");

            return Ok(categoriaAtualizada);
        }

        /// <summary>
        /// End-point que apagar uma categoria.
        /// </summary>
        /// <param name="idcategoria"> Id da categoria a ser excluida.</param>
        /// <returns></returns>
        [HttpDelete("{idcategoria}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(CategoriasDePosters))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteCategoria(int idcategoria)
        {
            _categoriasBusiness.Delete(idcategoria);
            return NoContent();
        }

    }
}
