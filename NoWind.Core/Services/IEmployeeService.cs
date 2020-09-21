using NoWind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employees>> GetAllEmployees();
        Task<Employees> GetEmployeeById(int id);
        Task<IEnumerable<Employees>> GetEmployeesByBoss(int bossId);
        Task<Employees> CreateEmployees(Employees employee);
        Task UpdateEmployees(Employees employeeToBeUpdated, Employees employee);
        Task DeleteEmployees(Employees employee);
    }
}
