using EMS.Models;
using EMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        [HttpGet("api/employee/GetAllEmployees")]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {

            var employees = _employeeRepo.GetAllEmployees();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("api/employee/GetEmployeeById/{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeRepo.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("api/employee/AddEmployee")]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeeRepo.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("api/employee/UpdateEmployee/{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var Employee = _employeeRepo.GetEmployeeById(id);
            if (Employee == null)
            {
                return NotFound();
            }

            Employee.FirstName = employee.FirstName;
            Employee.MiddleName = employee.MiddleName;
            Employee.LastName = employee.LastName;

            _employeeRepo.UpdateEmployee(Employee);

            return NoContent();
        }

        [HttpDelete("api/employee/DeleteEmployee/{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepo.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepo.DeleteEmployee(id);

            return NoContent();
        }
    }

}
