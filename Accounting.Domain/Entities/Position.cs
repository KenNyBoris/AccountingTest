using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<PositionEmployee> Employees { get; set; }
    }
}
