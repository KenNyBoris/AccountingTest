using Accounting.Domain.Abstract;
using Accounting.Domain.EFContext;
using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<string> CreateAsync(Employee employee)
        {
            var result = await _accountingContext.Employees.AddAsync(employee);
            await _accountingContext.SaveChangesAsync();
            return result.Entity.Id.ToString();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _accountingContext.Employees.Include(s => s.Positions).ThenInclude(s => s.Position).ToListAsync();
        }

        public async Task<Employee> GetDetailsAsync(string id)
        {
            return await _accountingContext.Employees.FindAsync(id);
        }
    }
}
