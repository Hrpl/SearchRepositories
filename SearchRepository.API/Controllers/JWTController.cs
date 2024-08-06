using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchRepository.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class JWTController : ControllerBase
    {

        // GET: api/<JWTController>
        [HttpGet("login/{username}")]
        public ActionResult Get([FromRoute] string username)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOption.KEY));

            var jwt = new JwtSecurityToken(
                    issuer: JwtOption.ISSUER,
                    audience: JwtOption.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

    }
}
