using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositries
{
    public class SqlWalkRepositry : IWalkRepositry
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public SqlWalkRepositry(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Walk>CreateAsync(Walk walk)
        {
            await nZWalksDbContext.Walks.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return (walk);
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
           var walkExisting = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkExisting == null)
            {
                return null;
            }
             nZWalksDbContext.Remove(walkExisting);
            await nZWalksDbContext.SaveChangesAsync();
            return (walkExisting);

        }

        public async Task<List<Walk>> GetAllWalkAsync()
        {
            return await nZWalksDbContext.Walks
                .Include("Difficalty")
                .Include("Region")
                .ToListAsync();
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
           return await nZWalksDbContext.Walks
                .Include("Difficalty")
                .Include("Region")
                .FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Walk?> updateWalkAsync( Guid id, Walk walk)
        {
            var walkExisting = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkExisting == null)
            {
                 return null;
            }
         
            walkExisting.Name = walk.Name;
            walkExisting.Description = walk.Description; 
            walkExisting.LengthInKm = walk.LengthInKm;
            walkExisting.WalkImageId= walk.WalkImageId;
            walkExisting.RegionId = walk.RegionId;
            walkExisting.DifficaltyId = walk.DifficaltyId; 
            await nZWalksDbContext.SaveChangesAsync();
            return walkExisting;
        }

    }
}
