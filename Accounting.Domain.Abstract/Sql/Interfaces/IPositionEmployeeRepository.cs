using System.Threading.Tasks;
using Accounting.Domain.Abstract.Sql.Entities;

namespace Accounting.Domain.Abstract.Sql.Interfaces
{
    public interface IPositionEmployeeRepository
    {
        Task InsertAsync(PositionEmployee item);
    }
}
