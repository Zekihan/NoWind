using Microsoft.EntityFrameworkCore;
using NoWind.Core.IRepositories;
using NoWind.Core.Models;
using NoWind.Data.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoWind.Data.Repositories
{
    public class OrderRepository : BaseRepository<Orders>, IOrderRepository
    {
        public OrderRepository(NorthwindContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            return await NorthwindContext.Orders
                .Include(a => a.OrderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Orders>> GetOrdersByCustomerIdAsync(string customerId)
        {
            return await NorthwindContext.Orders
                .Where(a => a.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Orders>> GetOrdersByEmployeeIdAsync(int employeeId)
        {
            return await NorthwindContext.Orders
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<Orders> GetOrderByIdAsync(int id)
        {
            return await NorthwindContext.Orders
                .Where(a => a.OrderId == id)
                .SingleOrDefaultAsync();
        }

        private NorthwindContext NorthwindContext
        {
            get { return Context as NorthwindContext; }
        }
    }
}
