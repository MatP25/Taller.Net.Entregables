using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private IDictionary<long, Models.Task> tasks;

        public TaskController()
        {
            tasks = new Dictionary<long, Models.Task>();
            tasks.Add(1, new Models.Task(1, "Task 1", "Description for Task 1", 5));
            tasks.Add(2, new Models.Task(2, "Task 2", "Description for Task 2", 3));
        }

        [HttpGet]
        public ActionResult<IList<Models.Task>> GetAll()
        {
            return Ok(tasks.Values.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Task> GetById(long id)
        {
            if (tasks.TryGetValue(id, out var item))
            {
                return Ok(item);
            }
            return NotFound(new { success = false, message = "Task not found" });
        }

        [HttpPost]
        public ActionResult<Models.Task> Create([FromBody] Models.Task task)
        {
            if (task == null || string.IsNullOrEmpty(task.Name))
            {
                return BadRequest("Task name cannot be null or empty.");
            }

            long newId = tasks.Keys.Max() + 1;
            task.Id = newId;
            tasks.Add(newId, task);
            return CreatedAtAction(nameof(GetById), new { id = newId }, task);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            if (tasks.Remove(id))
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}/assign/{employeeId}")]
        public ActionResult<Models.Task> AssignTask(long id, long employeeId, [FromServices] EmployeeController employeeController)
        {
            if (!tasks.TryGetValue(id, out var task))
            {
                return NotFound(new { success = false, message = "Task not found" });
            }

            var employeeResult = employeeController.LocalGetById(employeeId);
            if (employeeResult is null)
            {
                return NotFound(new { success = false, message = "Employee not found" });
            }
            
            task.AssignedTo = employeeResult;
            tasks[id] = task; // Update the task in the dictionary

            return Ok(new { success = true, message = "Task assigned successfully", data = task });
        }
    }
}