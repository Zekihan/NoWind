using Microsoft.EntityFrameworkCore;
using NoWind.Core.IRepositories;
using NoWind.Core.Models;
using NoWind.Data.Configurations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Data.Repositories
{
    public class ShipperRepository : BaseRepository<Shippers>, IShipperRepository
    {
        public ShipperRepository(NorthwindContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Shippers>> GetAllShippersAsync()
        {
            return await NorthwindContext.Shippers
                .Include(a => a.ShipperId)
                .ToListAsync();
        }

        public async Task<Shippers> GetShipperByIdAsync(int id)
        {
            return await NorthwindContext.Shippers
                .SingleOrDefaultAsync(a => a.ShipperId == id);
        }

        private NorthwindContext NorthwindContext
        {
            get { return Context as NorthwindContext; }
        }
    }
}
