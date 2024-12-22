using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositries
{
    public class SqlRegionRepositry : IRegionRepositry
    {
        private readonly NZWalksDbContext nZWalksDb;

        public SqlRegionRepositry(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDb = nZWalksDbContext;
        }
        public async Task<List<Region>> GetallRegionAsync()
        {
            return await nZWalksDb.Regions.ToListAsync();
        }


        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await nZWalksDb.Regions.FirstOrDefaultAsync(x => x.Id == id);        }

        public async Task<Region> CreateAsync(Region region)
        {
            await nZWalksDb.AddAsync(region);
            return (region);
             
        }

      
        public  async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var ExistingRegion = await nZWalksDb.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            ExistingRegion.Name=region.Name;
            ExistingRegion.Code=region.Code;
            ExistingRegion.RegionImageId=region.RegionImageId;

            await nZWalksDb.SaveChangesAsync();
            return (ExistingRegion);
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var ExistingRegion=await nZWalksDb.Regions.FirstOrDefaultAsync(x=>x.Id==id);
            if(ExistingRegion == null)
            {
                return null;
            }
            nZWalksDb.Regions.Remove(ExistingRegion);
            await nZWalksDb.SaveChangesAsync();
            return (ExistingRegion);
        }
    }
}
