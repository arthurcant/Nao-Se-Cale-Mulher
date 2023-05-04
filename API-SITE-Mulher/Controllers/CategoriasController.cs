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

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType(200, Type = typeof(PagedSearchVO<CategoriasDePosters>))]
        [ProducesResponseType(203)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(
            [FromQuery] string? name,
            string sortDirection,
            int pageSize,
            int page) 
        {
            return Ok(_categoriasBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        public IActionResult GetPosteresByIdCategoria(int id)
        {
            if(id <= 0) return BadRequest("Invalid Request");

            var tb_Usuario = _repository.ValidateCredentials(User.Identity.Name);

            var posteres = _categoriasBusiness.GetPosteresByIdCategoria(id, tb_Usuario);

            if (posteres == null) return BadRequest("Invalid Request");

            return Ok(posteres);
        }

        [HttpPost]
        [Route("registercategoria")]
        public IActionResult CreateCategoria([FromBody] CategoriasDePosters categoria) { 

            if(categoria is null) return BadRequest("Invalid Request");

            var categoriaCriada = _categoriasBusiness.Create(categoria);

            if (categoriaCriada is null) return BadRequest("Invalid Request");

            return Ok(categoriaCriada);
        }

        [HttpGet("{idPoster}/{idCategoria}")]
        public IActionResult AddCategoriasParaPoster(int idPoster, int idCategoria)
        {
            if(idPoster <= 0 && idCategoria <= 0) return BadRequest("Invalid Request");

            bool result = _categoriasBusiness.AddCategoriasParaPoster(idPoster, idCategoria);

            if (!result) return BadRequest("Invalid Request");

            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateCategoria([FromBody] CategoriasDePosters categoria)
        {
            if (categoria is null) return BadRequest("Invalid Request");

            var categoriaAtualizada = _categoriasBusiness.Update(categoria);

            if (categoriaAtualizada is null) return BadRequest("Invalid Request");

            return Ok(categoriaAtualizada);
        }

        [HttpDelete("{idposter}/{idcategoria}")]
        public IActionResult DeleteCategoria(int idposter, int idcategoria)
        {
            _categoriasBusiness.Delete(idcategoria);
            return NoContent();
        }

    }
}
