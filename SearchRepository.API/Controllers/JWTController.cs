using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SearchRepository.Application.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchRepository.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        protected readonly ILoginServices _loginServices;

        public JWTController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        // GET: api/<JWTController>
        [HttpGet("login/{username}")]
        public async Task<ActionResult> Get([FromRoute] string username)
        {
            var user = await _loginServices.Login(username);

            if (user == null) return Unauthorized(); 

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOption.KEY));

            var jwt = new JwtSecurityToken(
                    issuer: JwtOption.ISSUER,
                    audience: JwtOption.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                login = username
            };

            return Ok(response);
        }

    }
}
