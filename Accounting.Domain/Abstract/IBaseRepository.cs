using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        Task<string> CreateAsync(T item);

        Task<IEnumerable<T>> GetAllAsync();

    }
}
