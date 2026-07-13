using TaskManagerApi_03.Dtos.Tasks;

namespace TaskManagerApi_03.Dtos.Employees
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();
    }
}
