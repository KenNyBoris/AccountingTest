using System;

namespace Accounting.Domain.Abstract.Sql.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}