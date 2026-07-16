using Microsoft.EntityFrameworkCore;
using TaskManagerApi_03.Domain;
using TaskManagerApi_03.Domain.Exceptions;
using TaskManagerApi_03.Dtos.Employees;
using TaskManagerApi_03.Dtos.Tasks;
using TaskManagerApi_03.Infrastructure;

namespace TaskManagerApi_03.Application
{
    public class EmployeeUseCase
    {
        private readonly AppDbContext _context;
        public EmployeeUseCase(AppDbContext context)
        {
            _context = context;
        }
        public async Task<EmployeeDto> Create(CreateEmployee request)
        {
            var existingEmployee = await _context.Employees.AnyAsync(e => e.Email == request.Email);
            if (existingEmployee)
            {
                throw new ConflictException("El empleado con el mismo correo electrónico ya existe.");
            }

            var employee = new Employee(
                request.Name,
                request.Email,
                request.Department
                );
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return MapToDto(employee);
        }
        public async Task Update(Guid id, UpdateEmployee request)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new NotFoundException("Empleado no encontrado.");
            }
            employee.Update(request.Name, request.Email, request.Department, request.IsActive);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new NotFoundException("Empleado no encontrado.");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public async Task<EmployeeDto?> GetById(Guid id)
        {
            var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
            {
                return null;
            }
            return MapToDto(employee);
        }
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = await _context.Employees.AsNoTracking().Include(e => e.Tasks).ToListAsync();
            return employees.Select(MapToDto);
        }
        private static EmployeeDto MapToDto(Employee employee) => new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            Email = employee.Email,
            Department = employee.Department,
            IsActive = employee.IsActive,
            Tasks = employee.Tasks.Select(t => new TaskDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
            }).ToList()
        };
    }
}
