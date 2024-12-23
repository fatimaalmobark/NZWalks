﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Walk>walks { get; set; }   
    }
}
