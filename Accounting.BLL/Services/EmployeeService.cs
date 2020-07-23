using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels.Employee;
using Accounting.Domain.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Accounting.BLL.ViewModels;
using Accounting.Domain.Entities;
using Accounting.Domain.Repositories;

namespace Accounting.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly PositionEmployeeRepository _positionEmployeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IPositionRepository positionRepository,
            PositionEmployeeRepository positionEmployeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _positionEmployeeRepository = positionEmployeeRepository;
            _mapper = mapper;
        }
        public async Task<string> CreateAsync(CreateEmployeeViewModel createEmployeeViewModel)
        {
            var employee = _mapper.Map<Employee>(createEmployeeViewModel);
            employee.Id = Guid.NewGuid();
            var positionEmpoyee = new PositionEmployee
            {
                EmployeeId = employee.Id,
                PositionId = Guid.Parse(createEmployeeViewModel.PositionId)
            };
                await _positionEmployeeRepository
                .InsertAsync(positionEmpoyee); 
            employee.Positions = new List<PositionEmployee>{positionEmpoyee};
            var employeeId = await _employeeRepository.CreateAsync(employee);
            

            return employeeId;
        }

        public async Task<IEnumerable<GetAllEmployeeViewModel>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetAllEmployeeViewModel>>(employees);
            return result;
        }

        public async Task<GetEmployeeDetailsViewModel> GetDetailsAsync(string id)
        {
            var employee = await _employeeRepository.GetDetailsAsync(id);
            var employeeModel = _mapper.Map<GetEmployeeDetailsViewModel>(employee);
            return employeeModel;
        }
    }
}
