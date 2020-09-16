using NoWind.Core.Models;
using NoWind.Data.Configurations;
using System.Collections.Generic;
using NoWind.Core.IRepositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NoWind.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(NorthwindContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            return await NorthwindContext.Employees
                .Include(a => a.EmployeeId)
                .ToListAsync();
        }

        public async Task<Employees> GetEmployeeByIdAsync(int id)
        {
            return await NorthwindContext.Employees
                .SingleOrDefaultAsync(a => a.EmployeeId == id);
        }

        public async Task<IEnumerable<Employees>> GetEmployeesByBossAsync(int bossId)
        {
            return await NorthwindContext.Employees
                .Where(a => a.ReportsTo == bossId)
                .ToListAsync();
        }

        private NorthwindContext NorthwindContext
        {
            get { return Context as NorthwindContext; }
        }
    }
}
