using System.Collections.Generic;
using System.Threading.Tasks;
using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels;
using Accounting.BLL.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ActionName("get-all")]
        public async Task<IEnumerable<GetAllEmployeeViewModel>> GetAll()
        {
            var result = await _employeeService.GetAllAsync();
            return result;
        }

        [HttpPost]
        [ActionName("create")]
        public async Task<IActionResult> CreateAsync(CreateEmployeeViewModel employeeModel)
        {
            await _employeeService.CreateAsync(employeeModel);
            return Ok();
        }

        [HttpGet]
        public async Task<GetEmployeeDetailsViewModel> GetDetails(string id)
        {
            var result = await _employeeService.GetDetailsAsync(id);
            return result;
        }
    }
}
