using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Core.IRepositories
{
    public interface IShipperRepository : IRepository<Shippers>
    {
        Task<IEnumerable<Shippers>> GetAllShippersAsync();
        Task<Shippers> GetShipperByIdAsync(int id);
    }
}
