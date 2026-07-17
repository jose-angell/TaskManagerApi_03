using Microsoft.AspNetCore.Mvc;
using TaskManagerApi_03.Application;
using TaskManagerApi_03.Dtos.Employees;

namespace TaskManagerApi_03.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeUseCase _useCase;
        public readonly TaskUseCase _taskUseCase;
        public EmployeeController(EmployeeUseCase useCase, TaskUseCase taskUseCase)
        {
            _useCase = useCase;
            _taskUseCase = taskUseCase;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid employee ID.");
            }
            var employee = await _useCase.GetById(id);
            
            return Ok(employee);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _useCase.GetAll();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployee request)
        {
            var createdEmployee = await _useCase.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEmployee request)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid employee ID.");
            }
            await _useCase.Update(id, request);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid employee ID.");
            }
            await _useCase.Delete(id);
            return NoContent();
        }
        [HttpGet("{id:guid}/tasks")]
        public async Task<IActionResult> GetTasks([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid employee ID.");
            }
            var tasks = await _taskUseCase.GetByEmployeeId(id);
            return Ok(tasks);
        }
    }
}
