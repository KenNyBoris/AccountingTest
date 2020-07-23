using Accounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
                AppointmentDate = DateTime.Now.AddYears(-1),
                Salary = 5000
            };
            var middleEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Ivan",
                LastName = "Ivanovich",
                AppointmentDate = DateTime.Now.AddYears(-2),
                Salary = 2000
            };
            var seniorEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Anton",
                LastName = "Antonovich",
                AppointmentDate = DateTime.Now.AddYears(-6),
                Salary = 9999,
                DismissalDate = DateTime.Now.AddMonths(-2)
            };
            modelBuilder.Entity<Position>().HasData(juniorPosition, middlePosition, seniorPosition);
            modelBuilder.Entity<Employee>().HasData(juniorEmployee, middleEmployee, seniorEmployee);
            modelBuilder.Entity<PositionEmployee>().HasData(
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = juniorEmployee.Id,
                    PositionId = juniorPosition.Id
                },
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    PositionId = middlePosition.Id,
                    EmployeeId = middleEmployee.Id
                },
                new PositionEmployee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = seniorEmployee.Id,
                    PositionId = seniorPosition.Id
                });
        }
    }
}
