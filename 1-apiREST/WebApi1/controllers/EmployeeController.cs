using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private IDictionary<long, Employee> employees;

        public EmployeeController()
        {
            employees = new Dictionary<long, Employee>();
            employees.Add(1, new Employee(1, "John Doe"));
            employees.Add(2, new Employee(2, "Jane Smith"));
            employees.Add(3, new Employee(3, "Alice Johnson"));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public Employee? LocalGetById(long id)
        {
            if (employees.TryGetValue(id, out var employee))
            {
                return employee;
            }
            return null;
        }

        [HttpGet]
        public ActionResult<IList<Employee>> GetAll()
        {
            return Ok(employees.Values.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Employee> GetById(long id)
        {
            if (employees.TryGetValue(id, out var employee))
            {
                return Ok(employee);
            }
            return NotFound(new { success = false, message = "Employee not found" });
        }

        [HttpPost]
        public ActionResult<Employee> Create([FromBody] Employee employee)
        {
            if (employee == null || string.IsNullOrEmpty(employee.Name))
            {
                return BadRequest("Employee cannot be null or empty.");
            }

            long newId = employees.Keys.Max() + 1;
            employee.Id = newId;
            employees.Add(newId, employee);
            return CreatedAtAction(nameof(GetById), new { id = newId }, employee);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            if (employees.Remove(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}