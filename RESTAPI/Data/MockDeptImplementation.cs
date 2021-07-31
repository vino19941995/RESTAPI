using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Data
{
    public class MockDeptImplementation : IDepartmentRepo
    {
        private readonly AppDBContext appDBContext;

        public MockDeptImplementation(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<IEnumerable<Department>> GetAllDepartment()
        {
            return await appDBContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await appDBContext.Departments.FirstOrDefaultAsync(e => e.DepartmentID == departmentId);
           
        }
    }
}
