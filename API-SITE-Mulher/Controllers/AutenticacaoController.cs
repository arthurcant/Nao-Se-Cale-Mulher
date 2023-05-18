using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
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

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user) 
        {
            if (user is null) return BadRequest("Invalid client");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null) return Unauthorized();

            return Ok(token);
        }

        [HttpPost]
        [Route("registe")]
        public IActionResult Resgiste([FromBody] UsuarioRegisterVO user )
        {
            if (user == null) return BadRequest("Invalid register user");

            var usuarioRegistrado = _loginBusiness.RegisterUser(user);

            if (usuarioRegistrado == null) return BadRequest("The user was't registered with sucess.");

            //TODO: MUDAR RESPOSTA PARA CREATED 201
            return Ok(usuarioRegistrado);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] RefreshTokenVO tokenVo)
        {
            if (tokenVo is null) return BadRequest("Invalid client request");

            var token = _loginBusiness.ValidateCredentials(tokenVo);

            if (token is null) return BadRequest("Invalid client request");

            return Ok(token);
        }

        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _loginBusiness.RevokeToken(username);

            if (!result) return BadRequest("Invalid client request");
            return NoContent();
        }

    }
}
