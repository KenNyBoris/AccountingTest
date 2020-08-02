using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.BLL.ViewModels.Employee;
using Accounting.BLL.ViewModels.Position;
using Accounting.Domain.Abstract.NoSql.Entities;
using AutoMapper;

namespace Accounting.BLL.Configurations
{
    public class MongoMappingProfile : Profile
    {
        public MongoMappingProfile()
        {
            CreateMap<Employee, GetEmployeeDetailsViewModel>();
            CreateMap<Employee, GetAllEmployeeViewModel>()
            .ForMember(s => s.AppointmentDate,
            opt => opt.MapFrom(w => w.Positions
                .FirstOrDefault(pos => pos.AppointmentDate
                .Equals(w.Positions
            .Max(max => max.AppointmentDate))).AppointmentDate))
            .ForMember(s => s.DismissalDate,
            opt => opt.MapFrom(w => w.Positions
                .FirstOrDefault(pos => pos.DismissalDate == null
            || pos.DismissalDate.Equals(w.Positions
            .Max(maxOpt => maxOpt.DismissalDate))).DismissalDate))
            .ForMember(s => s.CurrentPositionName,
            opt => opt.MapFrom(w => w.Positions
                .FirstOrDefault(pos => pos.AppointmentDate
                .Equals(w.Positions
            .Max(maxOpt => maxOpt.AppointmentDate))).Name))
            .ForMember(s => s.Name, opt => opt.MapFrom(w => string.Concat(w.FirstName, " ", w.LastName)))
                .ForMember(s => s.Id, opt => opt.MapFrom(w => w._id));
            CreateMap<CreateEmployeeViewModel, Employee>();
            CreateMap<CreateEmployeeViewModel, Employee>();
            CreateMap<Position, GetAllPositionsViewModel>()
                .ForMember(s => s.Id, opt => opt.MapFrom(w => w._id));
            CreateMap<CreatePositionViewModel, Position>();

        }
    }
}
