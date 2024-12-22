using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositries
{
    public interface IRegionRepositry
    {
        Task<List<Region>> GetallRegionAsync();
        Task<Region> GetRegionByIdAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region?> UpdateAsync(Guid id,Region region);
    }
}
