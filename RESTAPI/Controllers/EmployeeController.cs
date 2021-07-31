using Microsoft.AspNetCore.Mvc;
using RESTAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo employee;

        public EmployeeController(IEmployeeRepo employee)
        {
            this.employee = employee;
        }
        [HttpGet("{search}")]
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, string gender)
        {
            try
            {
                var result = await employee.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }


        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employee.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retriving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employee.GetEmployee(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employees)
        {
            try
            {
               
                if (employees == null)
                    return BadRequest();
                var result = await employee.AddEmployee(employees);

                return CreatedAtAction(nameof(GetEmployee), new { id = result.ID }, result);
               
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating data to database");
            }
               
        }
        public async Task<ActionResult<Employee>> UpdateEmployee(int id,Employee employees)
        {
            try
            {

                if (id!=employees.ID)
                    return BadRequest("Employee ID mismatch");
                var existingemployeeid=await employee.GetEmployee(id);
                if (existingemployeeid == null)
                {
                    return NotFound($"employee id ={id} not found");
                }

                return await employee.UpdateEmployee(employees);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data to database");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {

                
                var existingemployeeid = await employee.GetEmployee(id);
                if (existingemployeeid == null)
                {
                    return NotFound($"employee id ={id} not found");
                }

                await employee.DeleteEmployee(id);
                return Ok($"employee id={id} has been deleted");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from database");
            }

        }
    }
}
