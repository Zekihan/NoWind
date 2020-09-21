using NoWind.Core.Models;
using NoWind.Data;
using NoWind.Data.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Services
{
    public class CustomerService : ICustomersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customers> CreateCustomer(Customers customers)
        {
            await _unitOfWork.Customers.AddAsync(customers);
            await _unitOfWork.CommitAsync();
            return customers;
        }

        public async Task DeleteCustomer(Customers customer)
        {
            _unitOfWork.Customers.Remove(customer);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Customers> GetCustomerById(string id)
        {
            return await _unitOfWork.Customers.GetCustomerByIdAsync(id);
        }

        public async Task<IEnumerable<Customers>> GetCustomersByCountry(string country)
        {
            return await _unitOfWork.Customers.GetCustomersByCountryAsync(country);
        }

        public async Task UpdateCustomer(Customers customerToBeUpdated, Customers customers)
        {
            customerToBeUpdated.CompanyName = customers.CompanyName;
            await _unitOfWork.CommitAsync();
        }
    }
}
