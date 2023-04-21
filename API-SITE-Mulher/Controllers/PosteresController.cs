using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PosteresController : ControllerBase
    {

        private readonly ILogger<Poster> _logger;
        private IPosteresBusiness _posteresBusiness;

        public PosteresController(ILogger<Poster> logger, IPosteresBusiness posteresBusiness)
        {
            _logger = logger;
            _posteresBusiness = posteresBusiness;
        }

        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType(200, Type = typeof(List<Poster>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(List<Poster>))]
        public IActionResult Get(
            [FromQuery] string name,
            string sortDirection,
            int pageSize,
            int page)
        {
            return Ok(_posteresBusiness.FindWithPagedSearch(sortDirection, pageSize, page, name));
        }

        [HttpPost]
        [Authorize("Bearer")]
        [Route("registerpost")]
        public IActionResult RegisterPoster(PosterRegisterVO poster)
        {
            if(poster == null) return BadRequest("Invalid Request");

            var email = User.Identity.Name;

            var posterRegistrado = _posteresBusiness.Create(poster, email);

            if (posterRegistrado == null) return BadRequest("Invalid Request");

            return Ok(posterRegistrado);

        }




    }
}
