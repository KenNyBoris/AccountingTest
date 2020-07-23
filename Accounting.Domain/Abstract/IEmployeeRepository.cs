using Accounting.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Abstract
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> GetDetailsAsync(string id);
    }
}
