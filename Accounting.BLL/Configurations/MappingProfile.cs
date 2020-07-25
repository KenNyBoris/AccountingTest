using Accounting.BLL.ViewModels.Employee;
using Accounting.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.BLL.ViewModels.Position;

namespace Accounting.BLL.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, GetAllEmployeeViewModel>()
                .ForMember(employeeViewModel => employeeViewModel.Name,
                    opt => opt.MapFrom(w => w.FirstName + " " + w.LastName))
                .ForMember(employeeViewModel => employeeViewModel.DismissalDate,
                    opt => opt.MapFrom(employee => employee.Positions
                        .FirstOrDefault(positionEmployee => positionEmployee.DismissalDate == null ||
                                             positionEmployee.DismissalDate == employee.Positions
                                                 .Max(m => m.DismissalDate)).DismissalDate))
                .ForMember(s => s.AppointmentDate,
                    opt => opt.MapFrom(employee => employee.Positions
                        .FirstOrDefault(positionEmployee => positionEmployee.AppointmentDate == employee.Positions
                            .Max(m => m.AppointmentDate)).AppointmentDate))
                .ForMember(s => s.CurrentPositionName,
                    opt => opt.MapFrom(employee => employee.Positions
                        .FirstOrDefault(positionEmployee => positionEmployee.AppointmentDate == employee.Positions
                            .Max(m => m.AppointmentDate)).Position.Name));
            CreateMap<Employee, GetEmployeeDetailsViewModel>();
            CreateMap<CreateEmployeeViewModel, Employee>();
            CreateMap<CreatePositionViewModel, Position>();
            CreateMap<Position, GetAllPositionsViewModel>();
        }
    }
}
