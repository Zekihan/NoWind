using NoWind.Core.IRepositories;
using System;
using System.Threading.Tasks;

namespace NoWind.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IEmployeeRepository Employees { get; }
        IShipperRepository Shippers { get; }
        Task<int> CommitAsync();
    }
}
