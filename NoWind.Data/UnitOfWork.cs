using NoWind.Core.IRespositories;
using NoWind.Data.Configurations;
using NoWind.Data.Repositories;
using System.Threading.Tasks;

namespace NoWind.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;
        private CustomerRepository _customerRepository;

        public UnitOfWork(NorthwindContext context)
        {
            this._context = context;
        }

        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
