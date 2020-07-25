using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels.Employee;
using Accounting.Domain.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
                PositionId = Guid.Parse(createEmployeeViewModel.Position.Id),
                AppointmentDate = createEmployeeViewModel.Position.AppointmentDate,
                DismissalDate = createEmployeeViewModel.Position.DismissalDate
            };
                await _positionEmployeeRepository
                .InsertAsync(positionEmpoyee); 
            employee.Positions = new List<PositionEmployee>{positionEmpoyee};
            var employeeId = await _employeeRepository.CreateAsync(employee);
            

            return employeeId;
        }

        public async Task<IEnumerable<GetAllEmployeeViewModel>> GetAllAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();

                var result = _mapper.Map<IEnumerable<GetAllEmployeeViewModel>>(employees);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }

        public async Task<GetEmployeeDetailsViewModel> GetDetailsAsync(string id)
        {
            var employee = await _employeeRepository.GetDetailsAsync(id);
            var employeeModel = _mapper.Map<GetEmployeeDetailsViewModel>(employee);
            return employeeModel;
        }
    }
}
