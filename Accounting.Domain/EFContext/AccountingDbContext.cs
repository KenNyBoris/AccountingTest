using Microsoft.EntityFrameworkCore;
using System;
using Accounting.Domain.Abstract.Sql.Entities;

namespace Accounting.Domain.EFContext
{
    public sealed class AccountingContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PositionEmployee> PositionEmployees { get; set; }

        public AccountingContext(DbContextOptions<AccountingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionEmployee>()
                .HasKey(bc => new { bc.EmployeeId, bc.PositionId });
            modelBuilder.Entity<PositionEmployee>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.Positions)
                .HasForeignKey(bc => bc.EmployeeId);
            modelBuilder.Entity<PositionEmployee>()
                .HasOne(bc => bc.Position)
                .WithMany(c => c.Employees)
                .HasForeignKey(bc => bc.PositionId);
            InitializeTestDate(modelBuilder);
        }

        private void InitializeTestDate(ModelBuilder modelBuilder)
        {
            var juniorPosition = new Position { Id = Guid.NewGuid(), Name = "Junior .NET Full-stack" };
            var middlePosition = new Position { Id = Guid.NewGuid(), Name = "Middle .NET Full-stack" };
            var seniorPosition = new Position { Id = Guid.NewGuid(), Name = "Senior .NET Back-end" };
            var juniorEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Boris",
                LastName = "Boguslavskiy",
                
                Salary = 5000
            };
            var middleEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Ivan",
                LastName = "Ivanovich",
                Salary = 2000
            };
            var seniorEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Anton",
                LastName = "Antonovich",
                Salary = 9999,
            };
            modelBuilder.Entity<Position>().HasData(juniorPosition, middlePosition, seniorPosition);
            modelBuilder.Entity<Employee>().HasData(juniorEmployee, middleEmployee, seniorEmployee);
            modelBuilder.Entity<PositionEmployee>().HasData(
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = juniorEmployee.Id,
                    AppointmentDate = DateTime.Now.AddYears(-1),
                    PositionId = juniorPosition.Id
                },
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    PositionId = middlePosition.Id,
                    AppointmentDate = DateTime.Now.AddYears(-2),
                    EmployeeId = middleEmployee.Id
                },
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = seniorEmployee.Id,
                    AppointmentDate = DateTime.Now.AddYears(-6),
                    DismissalDate = DateTime.Now.AddYears(-3),

                    PositionId = juniorPosition.Id
                },
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = seniorEmployee.Id,
                    AppointmentDate = DateTime.Now.AddYears(-3),
                    DismissalDate = DateTime.Now.AddYears(-1),
                    PositionId = middlePosition.Id
                },
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = seniorEmployee.Id,
                    PositionId = seniorPosition.Id,
                    AppointmentDate = DateTime.Now.AddYears(-1),

                }
             );
        }
    }
}
