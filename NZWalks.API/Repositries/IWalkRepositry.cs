using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositries
{
    public interface IWalkRepositry
    {

        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllWalkAsync();
    }
}
