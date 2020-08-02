using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Abstract.Sql.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }


        public virtual ICollection<PositionEmployee> Positions { get; set; }
    }
}
