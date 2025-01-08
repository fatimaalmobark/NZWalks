using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace NZWalks.API.Repositries
{
    public class TokenRepositry : ItokenRepositry
    {
        private readonly IConfiguration configuration;

        public TokenRepositry(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string CreateJWTToken(IdentityUser user, List<string> Roles)
        {
            //Claims
            var Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.Email, user.Email));
            foreach(var role in Roles)
            {

                Claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var Credentials = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(configuration["JWT:Issuer"],
            configuration["JWT:Audience"],
            Claims,
            expires:DateTime.Now.AddMinutes(10),
            signingCredentials:Credentials);

            return new JwtSecurityTokenHandler().WriteToken(Token);

              
           
               
              









        }
    }
}
