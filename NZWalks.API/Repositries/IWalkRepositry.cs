using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositries
{
    public interface IWalkRepositry
    {

        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllWalkAsync();
        Task<Walk?> GetWalkByIdAsync(Guid id); 
        Task<Walk?>  updateWalkAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
