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
    }
}
