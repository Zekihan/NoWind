using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Data.Services
{
    public interface ICustomersService
    {
        Task<IEnumerable<Customers>> GetAllCustomers();
        Task<Customers> GetCustomerById(string id);
        Task<IEnumerable<Customers>> GetCustomersByCountry(string country);
        Task<Customers> CreateCustomer(Customers customer);
        Task UpdateCustomer(Customers customerToBeUpdated, Customers customers);
        Task DeleteCustomer(Customers customer);
    }
}
