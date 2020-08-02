using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting.Domain.Abstract.Sql.Entities
{
    public class PositionEmployee : BaseEntity
    {
        public Guid PositionId { get; set; }

        public Guid EmployeeId { get; set; }

        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public DateTime AppointmentDate { get; set; }

        public DateTime? DismissalDate { get; set; }
    }
}
