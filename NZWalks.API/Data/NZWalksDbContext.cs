using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext 
    {
        public NZWalksDbContext(DbContextOptions dbContext):base(dbContext)
        {
            
        }

        public DbSet<Difficalty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seeding data to difficalties
            var difficalties = new List<Difficalty>
            {
                new Difficalty()
                {
                    Id=Guid.Parse("db00865a-39a2-4507-9481-ba5284e5e9d8"),
                    Name="EASY"
                },
                new Difficalty()
                {
                    Id=Guid.Parse("98526a56-dbbf-4b86-b9a2-dd2b526f0fc1"),
                    Name="MIDUEM"
                },
                new Difficalty()
                {
                    Id=Guid.Parse("e0db330e-fabe-4fe0-bc3d-c998ef244f14"),
                    Name="HARD"

                },
            };
            //seeding Difficalties to Database
            modelBuilder.Entity<Difficalty>().HasData(difficalties);


            //seeding data to Region
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id=Guid.Parse("f24a5ff2-9650-4756-a141-b0d705d89235"),
                    Name="KHARTOUM",
                    Code="249",
                    RegionImageId="SOME _IMAGE _FROM _KHARTOUM.png"

                },
                new Region()
                {
                      Id=Guid.Parse("3da2c37e-2676-4c96-8a03-282e0d784fee"),
                    Name="OMDURMAN",
                    Code="550",
                    RegionImageId="SOME _IMAGE _FROM _OMDURMAN.png"
                },
                new Region()
                {
                    Id=Guid.Parse("7cadcee0-6547-4b1d-87b3-685c21662829"),
                    Name="BAHRI",
                    Code="240",
                    RegionImageId="SOME _IMAGE _FROM_BAHRI.png"
                },
                new Region()
                {

                    Id=Guid.Parse("f8bc4a64-7538-4b60-b38b-32b5986a6ca5"),
                    Name="HALFA",
                    Code="241",
                    RegionImageId="SOME _IMAGE _FROM_HALFA.png"
                }
            };  
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
