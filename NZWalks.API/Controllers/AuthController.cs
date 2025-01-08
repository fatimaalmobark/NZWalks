
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositries;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public ItokenRepositry ItokenRepositry { get; }

        public AuthController(UserManager<IdentityUser> userManager,ItokenRepositry itokenRepositry)
        {
            this.userManager = userManager;
            ItokenRepositry = itokenRepositry;
        }
        //POST : api/poat/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var IdentityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var IdentityResult=await userManager.CreateAsync(IdentityUser, registerRequestDto.Password);
            if (IdentityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    IdentityResult = await userManager.AddToRolesAsync(IdentityUser, registerRequestDto.Roles);

                    if (IdentityResult.Succeeded)
                    {
                        return Ok("user was register, please Loggin");
                    }
                }
            }
            return BadRequest("something Went Wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var User = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if(User!=null)
            {
                var CheckPasswordResult= await userManager.CheckPasswordAsync(User,loginRequestDto.Password);
                {
                    if (CheckPasswordResult)
                    {
                        //Get the role for this User
                        var role=await userManager.GetRolesAsync(User);
                        if (role != null)
                        {
                            //create Token
                            var JWTtoken = ItokenRepositry.CreateJWTToken(User, role.ToList());

                            var reponse = new LoginResponseDto
                            {
                                JWTtoken = JWTtoken

                            };

                            //Create A Key Token 
                            return Ok(reponse);
                        }
                    }
                 
                }
                
            }
            return BadRequest("the username or password was wrong");
        }
    }
}
