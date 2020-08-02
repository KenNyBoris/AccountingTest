using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Accounting.Domain.Abstract.NoSql.Entities
{
    public class Position : BaseEntity
    {
        public string Name { set; get; }
    }
}
