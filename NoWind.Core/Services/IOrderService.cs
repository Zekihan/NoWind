using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Core.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> GetOrderById(int id);
        Task<IEnumerable<Orders>> GetOrdersByEmployeeId(int employeeId);
        Task<IEnumerable<Orders>> GetOrdersByCustomerId(string customerId);
        Task<Orders> CreateOrder(Orders order);
        Task UpdateOrder(Orders orderToBeUpdated, Orders order);
        Task DeleteOrder(Orders order);
    }
}
