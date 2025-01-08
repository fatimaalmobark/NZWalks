using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var ReaderRoleId = "c9622e8c-9b94-4ed8-90e3-f77ad0e95d35";
            var WriterRoleId = "f4c96308-6e56-4176-98d0-5aa08db78a7a";

            var roles = new List<IdentityRole>
            {
                new IdentityRole {

                    Id= ReaderRoleId,
                    ConcurrencyStamp=ReaderRoleId,
                    Name="reader",
                    NormalizedName="reader".ToUpper()

                },
                new IdentityRole
                {

                    Id= WriterRoleId,
                    ConcurrencyStamp = WriterRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
