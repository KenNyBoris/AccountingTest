using Accounting.Domain.EFContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.Domain.Abstract.Sql.Entities;
using Accounting.Domain.Abstract.Sql.Interfaces;
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

        public async Task CreateAsync(Position item)
        {
            var result = await _accountingContext.AddAsync(item);
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await _accountingContext.Positions.ToListAsync();
        }


        public async Task<Position> GetDetailsAsync(string id)
        {
            return await _accountingContext.Positions.FirstOrDefaultAsync(s => s.Id.Equals(Guid.Parse(id)));
        }

        public async Task<string> InsertAsync(Position position)
        {
            var result = await _accountingContext.Positions.AddAsync(position);
            await _accountingContext.SaveChangesAsync();
            return result.Entity.Id.ToString();
        }
    }
}
