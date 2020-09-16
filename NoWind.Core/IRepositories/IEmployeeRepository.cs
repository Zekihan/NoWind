using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Core.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employees>
    {
        Task<IEnumerable<Employees>> GetAllEmployeesAsync();
        Task<Employees> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employees>> GetEmployeesByBossAsync(int bossId);
    }
}
