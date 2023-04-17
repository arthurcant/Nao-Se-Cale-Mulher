using API_SITE_Mulher.Business;
using API_SITE_Mulher.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(_posteresBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }




    }
}
