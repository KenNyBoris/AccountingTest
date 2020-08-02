using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Abstract.NoSql.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }
        public List<PositionModel> Positions { get; set; }
    }

    public class PositionModel
    {
        public string Name { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime? DismissalDate { get; set; }

    }
}
