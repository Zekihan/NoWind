using NoWind.Core.Models;
using NoWind.Core.Services;
using NoWind.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Orders> CreateOrder(Orders order)
        {
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CommitAsync();
            return order;
        }

        public async Task DeleteOrder(Orders order)
        {
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Orders> GetOrderById(int id)
        {
            return await _unitOfWork.Orders.GetOrderByIdAsync(id);
        }

        public async Task<IEnumerable<Orders>> GetOrderByCustomerId(string customerId)
        {
            return await _unitOfWork.Orders.GetOrderByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<Orders>> GetOrderByEmployeeId(int employeeId)
        {
            return await _unitOfWork.Orders.GetOrderByEmployeeIdAsync(employeeId);
        }

        public async Task UpdateOrder(Orders orderToBeUpdated, Orders order)
        {
            orderToBeUpdated.ShippedDate = order.ShippedDate;
            await _unitOfWork.CommitAsync();
        }
    }
}
