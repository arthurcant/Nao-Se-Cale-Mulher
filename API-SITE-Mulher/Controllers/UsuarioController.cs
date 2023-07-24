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

        /// <summary>
        /// Retorna os dados dos usuários paginados.
        /// </summary>
        /// <param name="sortDirection"> Receber a instrução se os dados vão ser enviados pela ordem asc (ascendente) ou desc (decendente).</param>
        /// <param name="pageSize">Receber o números de elementos que seram enviados por retorno.</param>
        /// <param name="page">Especifica o número da página consultada.</param>
        /// <param name="emailOrNome">Parametro query opcional cujo recebe o email ou nome do usuário ser buscado.</param>
        /// <returns>Retorna um objeto PagedSearchVO.</returns>
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

        /// <summary>
        /// Retorna os dados do Usuário com a senhar atualizada.
        /// </summary>
        /// <param name="id">Coloque o id do usuário a se atualizado.</param>
        /// <param name="newPassword">Colocar a senhar que vai ser atualizada</param>
        /// <returns>Retorna um objeto Usuario.</returns>
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

        /// <summary>
        /// Retorna os dados do Usuário com a role atualizada.
        /// </summary>
        /// <param name="id">Coloque o id do usuário a se atualizado.</param>
        /// <param name="role">Colocar a role que vai ser atualizada</param>
        /// <returns>Retorna um objeto Usuario.</returns>
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

        /// <summary>
        /// O end-point que vai deleta um usuario do sistema
        /// </summary>
        /// <param name="id">Coloque o id do usuário que vai se deletado.</param>
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
