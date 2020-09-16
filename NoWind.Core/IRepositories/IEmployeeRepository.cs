using NoWind.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
