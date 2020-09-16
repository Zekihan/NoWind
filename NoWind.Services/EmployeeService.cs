using NoWind.Core.Models;
using NoWind.Core.Services;
using NoWind.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Employees> CreateEmployees(Employees employee)
        {
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.CommitAsync();
            return employee;
        }

        public async Task DeleteEmployees(Employees employee)
        {
            _unitOfWork.Employees.Remove(employee);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Employees>> GetAllEmployees()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employees> GetEmployeesById(int id)
        {
            return await _unitOfWork.Employees.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employees>> GetEmployeesByBoss(int bossId)
        {
            return await _unitOfWork.Employees.GetEmployeesByBossAsync(bossId);
        }

        public async Task UpdateEmployees(Employees employeeToBeUpdated, Employees employee)
        {
            employeeToBeUpdated.Title = employee.Title;
            await _unitOfWork.CommitAsync();
        }
    }
}
