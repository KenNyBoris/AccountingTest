using Accounting.Domain.Abstract;
using Accounting.Domain.EFContext;
using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Domain.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AccountingContext _accountingContext;

        public PositionRepository(AccountingContext accountingContext)
        {
            _accountingContext = accountingContext;
        }

        public async Task<string> CreateAsync(Position item)
        {
            var result = await _accountingContext.AddAsync(item);
            return result.Entity.Id.ToString();
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _accountingContext.Positions.ToListAsync();
        }

        public async Task<Position> GetByIdAsync(string positionId)
        {
            return await _accountingContext.Positions.FirstOrDefaultAsync(s => s.Id.Equals(Guid.Parse(positionId)));
        }

        public async Task<Position> GetEmloyeeCurrentPositionAsync(Guid employeeId)
        {
            var positionEmployeeEntity = await _accountingContext.PositionEmployees
                .FirstOrDefaultAsync(s => s.EmployeeId.Equals(employeeId) 
                                          && s.Employee.DismissalDate != null);
            var position = await _accountingContext.Positions
                .FirstOrDefaultAsync(s => s.Id.Equals(positionEmployeeEntity.PositionId));
            return position;
        }

        public async Task<string> InsertAsync(Position position)
        {
            var result = await _accountingContext.Positions.AddAsync(position);
            await _accountingContext.SaveChangesAsync();
            return result.Entity.Id.ToString();
        }
    }
}
