using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
using API_SITE_Mulher.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;
        private ILogger<AutenticacaoController> _logger;

        public AutenticacaoController(ILoginBusiness loginBusiness, ILogger<AutenticacaoController> logger)
        {
            _loginBusiness = loginBusiness;
            _logger = logger;
        }

        /// <summary>
        /// End-point de fazer o login.
        /// </summary>
        /// <returns>Retorna um Token.</returns>
        [HttpPost]
        [Route("signin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedSearchVO<Poster>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Signin([FromBody] UserVO user) 
        {
            if (user is null) return BadRequest("Invalid client");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null) return BadRequest();

            return Ok(token);
        }

        /// <summary>
        /// End-point para fazer o registro um usuário no sistema.
        /// </summary>
        /// <returns>Retorna o usuário resgistrado.</returns>
        [HttpPost]
        [Route("registe")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedSearchVO<Poster>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Resgiste([FromBody] UsuarioRegisterVO user )
        {
            if (user == null) return BadRequest("Invalid register user");

            var usuarioRegistrado = _loginBusiness.RegisterUser(user);

            if (usuarioRegistrado == null) return BadRequest("The user wasn't registered with sucess.");

            return Ok(usuarioRegistrado);
        }

        /// <summary>
        /// End-point para atualizar o acesso do token de um usuário já autenticado na API.
        /// </summary>
        /// <returns>Retorna o token com o acesso atualizado da API.</returns>
        [HttpPost]
        [Route("refresh")]
        [Authorize("Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedSearchVO<Poster>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Refresh([FromBody] RefreshTokenVO tokenVo)
        {
            if (tokenVo is null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(tokenVo);

            if (token is null) return BadRequest("Invalid client request");

            return Ok(token);
        }

        /// <summary>
        /// Esse end-point revogar o refresh token do usuário autenticado na API.
        /// </summary>
        /// <remarks>
        /// Ao revogar o refresh token do usuário ele só poderá usufruir dos recursos da API somente enquando o seu token ainda não expirou.
        /// </remarks>
        
        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedSearchVO<Poster>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(username);

            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }

    }
}
