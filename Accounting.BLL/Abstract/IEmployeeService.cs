using Accounting.BLL.ViewModels.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Accounting.BLL.ViewModels;

namespace Accounting.BLL.Abstract
{
    public interface IEmployeeService
    {
        Task<IEnumerable<GetAllEmployeeViewModel>> GetAllAsync();
        Task<string> CreateAsync(CreateEmployeeViewModel createEmployeeViewModel);
        Task<GetEmployeeDetailsViewModel> GetDetailsAsync(string id);
    }
}
