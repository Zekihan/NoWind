using NoWind.Core.IRespositories;
using System;
using System.Threading.Tasks;

namespace NoWind.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        Task<int> CommitAsync();
    }
}
