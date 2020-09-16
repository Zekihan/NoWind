using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Core.Services
{
    public interface IShipperService
    {
        Task<IEnumerable<Shippers>> GetAllShippers();
        Task<Shippers> GetShipperById(int id);
        Task<Shippers> CreateShipper(Shippers shipper);
        Task UpdateShipper(Shippers shipperToBeUpdated, Shippers shipper);
        Task DeleteShipper(Shippers shipper);
    }
}
