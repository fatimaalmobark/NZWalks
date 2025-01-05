using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }
        //POST : api/poat/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromRoute] RegisterRequestDto registerRequestDto)
        {

            return Ok(registerRequestDto);

        }
    
    }
}
