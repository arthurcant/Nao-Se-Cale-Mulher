using API_SITE_Mulher.Business;
using API_SITE_Mulher.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SITE_Mulher.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;

        public AutenticacaoController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
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

            return Ok(usuarioRegistrado);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
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
