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

        public async Task<List<Walk>> GetAllWalkAsync()
        {
            return await nZWalksDbContext.Walks.Include("Difficalty").Include("Region").ToListAsync();
        }
    }
}
