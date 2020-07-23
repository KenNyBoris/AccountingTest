using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.BLL.ViewModels.Employee
{
    public class GetAllEmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string PositionName { get; set; }
        public DateTime AppointmentDate { get; set; }

        public DateTime? DismissalDate { get; set; }
    }

}
