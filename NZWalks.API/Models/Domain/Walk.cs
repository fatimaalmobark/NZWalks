namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageId { get; set; }
        public Guid RegionId { get; set; }
        public Guid DiffiacltyId { get; set; }

        //Navigation Prpoerites
        public Difficalty Difficalty { get; set; }
        public Region Region  { get; set; }
    }
}
