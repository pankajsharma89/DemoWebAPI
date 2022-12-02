using DemoWebAPI.Data;
using DemoWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DemoAPIDbContext dbContext;

        public RegionRepository(DemoAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
      

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }
    }
}
