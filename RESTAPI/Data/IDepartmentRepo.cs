using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Data
{
    interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> GetAllDepartment();
        Task<Department> GetDepartment(int departmentId);
            
    }
}
