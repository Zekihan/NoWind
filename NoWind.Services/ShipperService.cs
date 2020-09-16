using NoWind.Core.Models;
using NoWind.Core.Services;
using NoWind.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShipperService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Shippers> CreateShipper(Shippers shipper)
        {
            await _unitOfWork.Shippers.AddAsync(shipper);
            await _unitOfWork.CommitAsync();
            return shipper;
        }

        public async Task DeleteShipper(Shippers shipper)
        {
            _unitOfWork.Shippers.Remove(shipper);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Shippers>> GetAllShippers()
        {
            return await _unitOfWork.Shippers.GetAllAsync();
        }

        public async Task<Shippers> GetShipperById(int id)
        {
            return await _unitOfWork.Shippers.GetShipperByIdAsync(id);
        }

        public async Task UpdateShipper(Shippers shipperToBeUpdated, Shippers shipper)
        {
            shipperToBeUpdated.Phone = shipper.Phone;
            await _unitOfWork.CommitAsync();
        }
    }
}
