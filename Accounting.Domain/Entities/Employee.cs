using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime? DismissalDate { get; set; }

        public virtual ICollection<PositionEmployee> Positions { get; set; }
    }
}
