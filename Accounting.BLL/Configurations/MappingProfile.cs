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
                .ForMember(s => s.Name,
                opt => opt.MapFrom(w => w.FirstName + " " + w.LastName))
                .ForMember(s => s.PositionName, opt => opt.MapFrom(w => w.Positions.FirstOrDefault().Position.Name));
            CreateMap<Employee, GetEmployeeDetailsViewModel>();
            CreateMap<CreateEmployeeViewModel, Employee>();
            CreateMap<CreatePositionViewModel, Position>();
            CreateMap<Position, GetAllPositionsViewModel>();
        }
    }
}
