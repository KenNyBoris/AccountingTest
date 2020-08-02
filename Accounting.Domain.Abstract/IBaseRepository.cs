using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Abstract.Sql.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T item);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetDetailsAsync(string id);

    }
}
