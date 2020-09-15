using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Core.IRespositories
{
    public interface ICustomerRepository : IRepository<Customers>
    {
        Task<IEnumerable<Customers>> GetAllCustomersAsync();
        Task<Customers> GetCustomerByIdAsync(string id);
        Task<IEnumerable<Customers>> GetCustomerByCountryAsync(string country);
    }
}
