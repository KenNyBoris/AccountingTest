using Accounting.Domain.Abstract.NoSql.Entities;
using Accounting.Domain.Abstract.Sql.Interfaces;

namespace Accounting.Domain.Abstract.NoSql.Interfaces
{
    public interface IEmployeeNoSqlRepository : IBaseRepository<Employee>
    {
    }
}
