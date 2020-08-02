using System.Threading.Tasks;
using Accounting.Domain.Abstract.Sql.Entities;
using Accounting.Domain.Abstract.Sql.Interfaces;
using Accounting.Domain.EFContext;

namespace Accounting.Domain.Repositories
{
    public class PositionEmployeeRepository : IPositionEmployeeRepository
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
