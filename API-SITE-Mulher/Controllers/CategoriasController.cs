using API_SITE_Mulher.Business;
using API_SITE_Mulher.Model;
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
        private ILogger<CategoriasController> _logger;

        public CategoriasController(ICategoriasBusiness categoriasBusiness, ILogger<CategoriasController> logger)
        {
            _categoriasBusiness = categoriasBusiness;
            _logger = logger;
        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        public IActionResult Get(
            [FromQuery] string? name,
            string sortDirection,
            int pageSize,
            int page) 
        {
            return Ok(_categoriasBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        [HttpPost]
        [Route("registercategoria")]
        public IActionResult CreateCategoria([FromBody] CategoriasDePosters categoria) { 

            if(categoria is null) return BadRequest("Invalid Request");

            var categoriaCriada = _categoriasBusiness.Create(categoria);

            if (categoriaCriada is null) return BadRequest("Invalid Request");

            return Ok(categoriaCriada);
        }

        [HttpPost("{idPoster}")]
        public IActionResult AddCategoriasParaPoster([FromBody] IdsCategoria ids, int idPoster = 0)
        {
            if(idPoster == 0 && ids is null) return BadRequest("Invalid Request");

            bool result = _categoriasBusiness.AddCategoriasParaPoster(idPoster, ids);

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

        [HttpDelete("{idcategoria}")]
        public IActionResult DeleteCategoria(int idcategoria)
        {
            _categoriasBusiness.Delete(idcategoria);
            return NoContent();
        }

    }
}
