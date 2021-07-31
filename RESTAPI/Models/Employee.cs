using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Models
{
    public class Employee
    {
        internal readonly object Department;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required]
        [MinLength(2,ErrorMessage="Firstname should atleast contain 2 character")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public Department DepartmentName { get; set; }
    }
}
