using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Accounting.BLL.Abstract;
using Accounting.BLL.ViewModels.Employee;
using Accounting.Domain.Abstract.NoSql.Entities;
using Accounting.Domain.Abstract.NoSql.Interfaces;
using Accounting.Domain.Abstract.Sql.Interfaces;
using AutoMapper;

namespace Accounting.BLL.Services.NoSql
{
    public class EmployeeNoSqlService : IEmployeeService
    {
        private readonly IEmployeeNoSqlRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IPositionNoSqlRepository _positionRepository;

        public EmployeeNoSqlService(IEmployeeNoSqlRepository employeeRepository,
            IPositionNoSqlRepository positionRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateEmployeeViewModel createEmployeeViewModel)
        {
            var employee = new Employee();
            employee = _mapper.Map<Employee>(createEmployeeViewModel);
            var position = await _positionRepository.GetDetailsAsync(createEmployeeViewModel.Position.Id);
            var positionModel = new PositionModel();
            positionModel.Name = position.Name;
            positionModel.DismissalDate = createEmployeeViewModel.Position.DismissalDate;
            positionModel.AppointmentDate = createEmployeeViewModel.Position.AppointmentDate;
            employee.Positions = new List<PositionModel>();
            employee.Positions.Add(positionModel);
            await _employeeRepository.CreateAsync(employee);
        }

        public async Task<IEnumerable<GetAllEmployeeViewModel>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var resultEmployees = _mapper.Map<IEnumerable<GetAllEmployeeViewModel>>(employees);
            return resultEmployees;
        }

        public async Task<GetEmployeeDetailsViewModel> GetDetailsAsync(string id)
        {
            var employee = await _employeeRepository.GetDetailsAsync(id);
            var resultEmployee = _mapper.Map<GetEmployeeDetailsViewModel>(employee);
            return resultEmployee;
        }
    }
}
