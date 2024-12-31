using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(3,ErrorMessage ="the max length is 10")]
        public string Name { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "the max length is 10")]
        public string Description { get; set; }
        [Required]
        public double LengthInKm { get; set; }
       
        public string? WalkImageId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
        [Required]
        public Guid DifficaltyId { get; set; }
        

        //Navigation Prpoerites
        public Difficalty Difficalty { get; set; }
        public Region Region  { get; set; }

    }
}
