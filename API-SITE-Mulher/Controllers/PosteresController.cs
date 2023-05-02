using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
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

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        public IActionResult Get(
            string sortDirection,
            int pageSize,
            int page,
            [FromQuery] string? title
            )
        {
            var tb_Usuario = _repository.ValidateCredentials(User.Identity.Name);
            return Ok(_posteresBusiness.FindWithPagedSearch(sortDirection, pageSize, page, tb_Usuario, title));
        }

        [HttpPost]
        [Route("registerpost")]
        public IActionResult RegisterPoster(PosterVO poster)
        {
            if (poster == null) return BadRequest("Invalid Request");

            var email = User.Identity.Name;

            var posterRegistrado = _posteresBusiness.Create(poster, email);

            if (posterRegistrado == null) return BadRequest("Invalid Request");

            return Ok(posterRegistrado);

        }

        [HttpPost]
        [Route("updateposter")]
        public IActionResult UpdatePoster(Poster poster)
        {
            if (poster is null) return BadRequest("Invalid Request");

            var tb_Usuario = _repository.ValidateCredentials(User.Identity.Name);

            var posterUpdated = _posteresBusiness.Update(poster, tb_Usuario);

            if (posterUpdated is null) return BadRequest("Poster not updated");

            return Ok(posterUpdated);
        }

        [HttpDelete("{id}")]
        [Route("deleteposter")]
        public IActionResult DeletePoster(int id)
        {
            _posteresBusiness.DeleteById(id);
            return NoContent();
        }

    }
}
