using Microsoft.AspNetCore.Mvc;
using TaskManagerApi_03.Application;
using TaskManagerApi_03.Dtos.Tasks;

namespace TaskManagerApi_03.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskUseCase _useCase;
        public TaskController(TaskUseCase useCase)
        {
            _useCase = useCase;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid task ID.");
            }
            var task = await _useCase.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTask request)
        {
            var createdTask = await _useCase.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTask request)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid task ID.");
            }
            await _useCase.Update(id, request);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid task ID.");
            }
            await _useCase.Delete(id);
            return NoContent();
        }
        [HttpGet("status={status:string}&search={search:string}")]
        public async Task<IActionResult> GetAll([FromRoute] string status, [FromRoute] string search)
        {
            var tasks = await _useCase.GetAll(status, search);
            return Ok(tasks);
        }
        [HttpGet("/pending")]
        public async Task<IActionResult> GetPendingTasks()
        {
            var tasks = await _useCase.GetPendingTasks();
            return Ok(tasks);
        }
        [HttpGet("/overdue")]
        public async Task<IActionResult> GetOverdueTasks()
        {
            var tasks = await _useCase.GetTasksOverdue();
            return Ok(tasks);
        }
        [HttpGet("/priority={priority:string}")]
        public async Task<IActionResult> GetTasksByPriority([FromRoute] string priority)
        {
            var tasks = await _useCase.GetByPriority(priority);
            return Ok(tasks);
        }
    }
}
