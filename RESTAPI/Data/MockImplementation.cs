using RESTAPI.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace RESTAPI.Data
{
    public class MockImplementation : IEmployeeRepo
    {
        private readonly AppDBContext AppDBContext;

        public MockImplementation(AppDBContext AppDBContext)
        {
            this.AppDBContext = AppDBContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            if (employee.Department != null)
            {
                AppDBContext.Entry(employee.Department).State =EntityState.Unchanged;
            }
            var result= await AppDBContext.Employees.AddAsync(employee);
           await  AppDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var result = await AppDBContext.Employees
                .FirstOrDefaultAsync(e => e.ID == employeeId);

            if (result != null)
            {
                AppDBContext.Employees.Remove(result);
                await AppDBContext.SaveChangesAsync();
            }
        }


        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await AppDBContext.Employees.FirstOrDefaultAsync(e => e.ID == employeeId);
            
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return  await AppDBContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
            
        }

        public async  Task<IEnumerable<Employee>> GetEmployees()
        {
            return await AppDBContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, string gender)
        {
            IQueryable < Employee > query= AppDBContext.Employees;

            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)|e.LastName.Contains(name));
            }
            if(!string.IsNullOrEmpty(gender))
            {
                query = query.Where(e => e.Gender.Contains(gender));
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await AppDBContext.Employees
                .FirstOrDefaultAsync(e => e.ID == employee.ID);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
               
                result.Gender = employee.Gender;
                if (employee.DepartmentID != 0)
                {
                    result.DepartmentID = employee.DepartmentID;
                }
               
              await AppDBContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
