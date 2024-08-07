using Microsoft.AspNetCore.Mvc;
using SearchRepository.Application.Interface;
using SearchRepository.Domen.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _userRepository.GetUsers());
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            try
            {
                await _userRepository.AddUser(user);
                return Created();
            }
            catch 
            {
                return BadRequest();
            }
            
        }

    }
}
