using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.BLL.ViewModels.Employee
{
    public class GetEmployeeDetailsViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime? DismissalDate { get; set; }

        public IEnumerable<GetEmployeeDetailsPositionModelViewModel> Positions { get; set; }
    }

    public class GetEmployeeDetailsPositionModelViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
