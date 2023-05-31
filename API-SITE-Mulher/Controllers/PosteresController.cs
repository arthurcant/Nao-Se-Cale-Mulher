using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Model.Domain;
using API_SITE_Mulher.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    [Authorize("Bearer")]
    public class PosteresController : ControllerBase
    {
        private readonly ILogger<Poster> _logger;
        private IUsersRepository _repository;
        private IPosteresBusiness _posteresBusiness;

        public PosteresController(ILogger<Poster> logger, IUsersRepository repository, IPosteresBusiness posteresBusiness)
        {
            _logger = logger;
            _repository = repository;
            _posteresBusiness = posteresBusiness;
        }

        /// <summary>
        /// Retorna os dados dos posteres paginados.
        /// </summary>
        /// <param name="sortDirection"> Receber a instrução se os dados vão ser enviados pela ordem asc (ascendente) ou desc (decendente).</param>
        /// <param name="pageSize">Receber o números de elementos que seram enviados por retorno.</param>
        /// <param name="page">Especifica o número da página consultada.</param>
        /// <param name="title">Parametro query opcional cujo recebe o nome do titulo da categoria a ser buscada.</param>
        /// <returns>Retorna um objeto PagedSearchVO.</returns>
        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedSearchVO<Poster>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Get(
            [FromQuery] string? title,
            string sortDirection,
            int pageSize,
            int page)
        {
            var tb_Usuario = _repository.ValidateCredentials(User.Identity.Name);
            var pagedSearchVO = _posteresBusiness.FindWithPagedSearch(sortDirection, pageSize, page, tb_Usuario, title);

            if (pagedSearchVO == null) return BadRequest("Invalid Request");

            return Ok(pagedSearchVO);
        }

        /// <summary>
        ///  O end-point que registrar um poster.
        /// </summary>
        /// <param name="poster"></param>
        /// <remarks>
        /// No "tags": [ 0 ] você pode passar os números de Ids de categorias já existentes no sistema para está adicionando ao novo poster registrado.
        /// </remarks>
        /// <returns>retorna um poster registrado.</returns>
        [HttpPost]
        [Route("registerpost")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(tb_poster))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RegisterPoster(PosterVO poster)
        {
            if (poster == null) return BadRequest("Invalid Request");

            var email = User.Identity.Name;

            var posterRegistrado = _posteresBusiness.Create(poster, email);

            if (posterRegistrado == null) return BadRequest("Invalid Request");

            return Ok(posterRegistrado);

        }

        /// <summary>
        /// O end-point Atualizar o poster.
        /// </summary>
        /// <param name="poster"></param>
        /// <returns>Retorna o objeto do poster atualizado.</returns>
        [HttpPost]
        [Route("updateposter")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Poster))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdatePoster(Poster poster)
        {
            if (poster is null) return BadRequest("Invalid Request");

            var tb_Usuario = _repository.ValidateCredentials(User.Identity.Name);

            var posterUpdated = _posteresBusiness.Update(poster, tb_Usuario);

            if (posterUpdated is null) return BadRequest("Poster not updated");

            return Ok(posterUpdated);
        }

        /// <summary>
        /// O end-point Atualizar o atributo UrlImagePoster de um poster.
        /// </summary>
        /// <param name="poster"></param>
        [HttpPatch]
        [Route("updateUrlImagePoster/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateUrlImagePoster(int id, ImageUrlVO imageURL)
        {
            if (!(id > 0 && imageURL is not null)) return BadRequest("Invalid Request");

            var IsPosterUpdate = _posteresBusiness.UpdateImageUrlPoster(id, imageURL);

            if (IsPosterUpdate == false) return BadRequest("Invalid Request");

            return NoContent();
        }

        /// <summary>
        /// O end-point que deletar um poster.
        /// </summary>
        /// <param name="poster"></param>
        /// <returns>Retorna o objeto do poster atualizado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletePoster(long id)
        {
            if (id <= 0) return BadRequest();

            _posteresBusiness.DeleteById((int)id);
            return NoContent();
        }

    }
}
