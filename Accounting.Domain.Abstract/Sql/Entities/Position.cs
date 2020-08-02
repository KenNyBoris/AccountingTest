using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Domain.Abstract.Sql.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<PositionEmployee> Employees { get; set; }
    }
}
