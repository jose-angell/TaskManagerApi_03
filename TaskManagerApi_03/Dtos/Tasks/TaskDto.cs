using TaskManagerApi_03.Domain;
using TaskManagerApi_03.Dtos.Employees;

namespace TaskManagerApi_03.Dtos.Tasks
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset CreateAt { get; set; }
        public EmployeeDto? Employee { get; set; }
    }
}
