using Accounting.Domain.Abstract.Sql.Entities;
using Accounting.Domain.Abstract.Sql.Interfaces;
using Accounting.Domain.EFContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Accounting.Domain.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AccountingContext _accountingContext;

        public EmployeeRepository(AccountingContext accountingContext)
        {
            _accountingContext = accountingContext;
        }

        public async Task CreateAsync(Employee employee)
        {
            await _accountingContext.Employees.AddAsync(employee);
            await _accountingContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _accountingContext.Employees
                .Include(s => s.Positions).ThenInclude(s => s.Position).ToListAsync();
        }

        public async Task<Employee> GetDetailsAsync(string id)
        {
            return await _accountingContext.Employees.FindAsync(id);
        }
    }
}
