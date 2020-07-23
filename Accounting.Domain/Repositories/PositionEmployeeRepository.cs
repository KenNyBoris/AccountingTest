using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Accounting.Domain.EFContext;
using Accounting.Domain.Entities;

namespace Accounting.Domain.Repositories
{
    public class PositionEmployeeRepository
    {
        private readonly AccountingContext _accountingContext;

        public PositionEmployeeRepository(AccountingContext accountingContext)
        {
            _accountingContext = accountingContext;
        }

        public async Task InsertAsync(PositionEmployee model)
        {
           await _accountingContext.PositionEmployees.AddAsync(model);
        }

    }
}
