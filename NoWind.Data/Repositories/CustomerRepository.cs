using Microsoft.EntityFrameworkCore;
using NoWind.Core.IRepositories;
using NoWind.Core.Models;
using NoWind.Data.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoWind.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(NorthwindContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Customers>> GetAllCustomersAsync()
        {
            return await NorthwindContext.Customers
                .Include(a => a.CompanyName)
                .ToListAsync();
        }

        public async Task<Customers> GetCustomerByIdAsync(string id)
        {
            return await NorthwindContext.Customers
                .SingleOrDefaultAsync(a => a.CustomerId == id);
        }

        public async Task<IEnumerable<Customers>> GetCustomersByCountryAsync(string country)
        {
            return await NorthwindContext.Customers
                .Where(a => a.Country == country)
                .ToListAsync();
        }

        private NorthwindContext NorthwindContext
        {
            get { return Context as NorthwindContext; }
        }
    }
}
