using DemoWebAPI.Models.Domain;

namespace DemoWebAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
