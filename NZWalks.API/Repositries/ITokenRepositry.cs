using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repositries
{
    public interface ItokenRepositry
    {
        string CreateJWTToken(IdentityUser user, List<string> Roles);
    }
}
