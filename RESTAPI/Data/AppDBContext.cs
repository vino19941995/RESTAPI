using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName="IT" }) ;
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID=2, DepartmentName="HR"});
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 3, DepartmentName = "PayRoll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 4, DepartmentName = "Admin" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    ID = 1,
                    FirstName = "John",
                    LastName = "Peter",
                    Gender = "Male",
                    Email = "john@gmail.com",
                    DepartmentID =1 ,
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    ID = 2,
                    FirstName = "John1",
                    LastName = "Peter",
                    Gender = "Male",
                    Email = "john@gmail.com",
                    DepartmentID = 2,
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    ID = 3,
                    FirstName = "John2",
                    LastName = "Peter",
                    Gender = "Male",
                    Email = "john@gmail.com",
                    DepartmentID = 3,
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    ID = 4,
                    FirstName = "John3",
                    LastName = "Peter",
                    Gender = "Male",
                    Email = "john@gmail.com",
                    DepartmentID = 4,
                });
        }
    }
}