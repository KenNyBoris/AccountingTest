using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.BLL.ViewModels.Employee
{
    public class CreateEmployeeViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime? DismissalDate { get; set; }

        public string PositionId { get; set; }
    }
}
