using Microsoft.EntityFrameworkCore;
using TaskManagerApi_03.Domain;
using TaskManagerApi_03.Dtos.Employees;
using TaskManagerApi_03.Dtos.Tasks;
using TaskManagerApi_03.Infrastructure;

namespace TaskManagerApi_03.Application
{
    public class TaskUseCase
    {
        private readonly AppDbContext _context;
        public TaskUseCase(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TaskDto> Create(CreateTask request)
        {
            var task = new Tasks(
                request.Title,
                request.Description,
                request.Priority,
                request.Status,
                request.DueDate,
                request.EmployeeId
                );
            await _context.AddAsync(task);
            await _context.SaveChangesAsync();
            return MapToDto(task);
        }
        public async Task Update(Guid id, UpdateTask request)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                throw new InvalidOperationException("Tarea no encontrada.");
            }
            task.Update(request.Title, request.Description, request.Priority, request.Status, request.DueDate, request.EmployeeId);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                throw new InvalidOperationException("Tarea no encontrada.");
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        public async Task<TaskDto?> GetById(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return null;
            }
            return MapToDto(task);
        }
        public async Task<IEnumerable<TaskDto>> GetAll(string? status, string? searchTerm)
        {
            var tasks = await _context.Tasks
                .Where(t => (string.IsNullOrEmpty(status) || t.Status == status) &&
                (string.IsNullOrEmpty(searchTerm) || t.Title.ToLower().Contains(searchTerm.ToLower())
                                                  || t.Description.ToLower().Contains(searchTerm.ToLower()))
                ).ToListAsync();
            return tasks.Select(MapToDto);
        }
        private TaskDto MapToDto(Tasks tasks) => new TaskDto
        {
            Id = tasks.Id,
            Title = tasks.Title,
            Description = tasks.Description,
            Priority = tasks.Priority,
            Status = tasks.Status,
            DueDate = tasks.DueDate,
            CreateAt = tasks.CreateAt,
            Employee = new EmployeeDto
            {
                Id = tasks.Employee?.Id ?? Guid.Empty,
                Name = tasks.Employee?.Name ?? string.Empty,
                Email = tasks.Employee?.Email ?? string.Empty,
                Department = tasks.Employee?.Department ?? string.Empty,
                IsActive = tasks.Employee?.IsActive ?? false
            }
        };
    }
}
