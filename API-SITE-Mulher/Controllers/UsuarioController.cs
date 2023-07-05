using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using API_SITE_Mulher.Repository;
using API_SITE_Mulher.Repository.Implementations;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    [Authorize("Bearer")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private IUsersBusiness iUserBusiness;
        private IUsersRepository repository;

        public UsuarioController(ILogger<UsuarioController> logger, IUsersBusiness iUserBusiness, IUsersRepository repository)
        {
            _logger = logger;
            this.iUserBusiness = iUserBusiness;
            this.repository = repository;
        }


        [HttpGet("{sortDirection}/{pageSize}/{page}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedSearchVO<Usuario>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetAllUsers(
            [FromQuery] string? emailOrNome,
            string sortDirection, 
            int pageSize, 
            int page)
        {
            var result = iUserBusiness.FindWithPagedSearch(sortDirection, pageSize, page, emailOrNome);

            if (result == null)
            {
                return BadRequest("Invalid request");
            }

            return Ok(result);   
        }

        [HttpGet("{id}/{newPassword}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult ChangePassword(int id, string newPassword) 
        {
            if (id <= 0 && string.IsNullOrEmpty(newPassword)) return BadRequest("invalid request");

            var userUpdated = iUserBusiness.ChangePassword(id, repository.ComputerHash(newPassword, new SHA256CryptoServiceProvider() ));

            if (userUpdated == null) return BadRequest("invalid request");

            return Ok(userUpdated);
        }

        [HttpPatch("{id}/{role}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateRoleUser(int id, int role)
        {
            if (id <= 0 && role < 0) return BadRequest("invalid request");

            var userUpdated = iUserBusiness.UpdateRoleUser(id, role);

            if (userUpdated == null) return BadRequest("invalid request");

            return Ok(userUpdated);


        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeleteUser(long id)
        {
            if (id <= 0) return BadRequest();

            iUserBusiness.DeleteById((int)id);
            return NoContent();
        }


    }
}
