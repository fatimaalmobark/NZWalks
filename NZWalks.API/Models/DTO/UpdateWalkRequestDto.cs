﻿using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageId { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficaltyId { get; set; }
 

    }
}
