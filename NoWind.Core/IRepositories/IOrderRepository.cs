using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Core.IRepositories
{
    public interface IOrderRepository : IRepository<Orders>
    {
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task<Orders> GetOrderByIdAsync(int id);
        Task<IEnumerable<Orders>> GetOrderByCustomerIdAsync(string customerId);
        Task<IEnumerable<Orders>> GetOrderByEmployeeIdAsync(int employeeId);
    }
}
