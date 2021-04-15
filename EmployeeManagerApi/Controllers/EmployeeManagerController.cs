using EmployeeManagerApi.Model;
using EmployeeManagerApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagerApi.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class EmployeeManagerController : ControllerBase
    {
        private IEmployeeManagerService Service;

        public EmployeeManagerController(IEmployeeManagerService service)
        {
            Service = service;
        }
        [HttpGet("/get")]
        public IActionResult Get()
        {
            return Ok(Service.GetAllEmployee());
        }
        [HttpPost("/get/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                return Ok(Service.FindEmployeeById(id));
            }
            catch (EmployeeNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPost("/post")]
        public IActionResult AddNewEmployee([FromBody] Employee newEmployee)
        {
            var createdEmployee = Service.AddNewEmployee(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
        }
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Service.DeleteEmployee(id);
            return Ok();
        }

        [HttpPut("/put")]
        public IActionResult UpdateEmployee([FromBody] Employee newEmployeeData)
        {
            var updatedEmployee = Service.UpdateEmployee(newEmployeeData);
            return Ok(updatedEmployee);
        }

    }
}
