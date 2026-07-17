using TaskManagerApi_03.Domain.Exceptions;

namespace TaskManagerApi_03.Domain
{
    public class Tasks
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Priority { get; private set; }
        public string Status { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public DateTimeOffset CreateAt { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee? Employee { get; private set; } 
        private Tasks()
        {
            Title = string.Empty;
            Description = string.Empty;
            Priority = string.Empty;
            Status = string.Empty;
            EmployeeId = Guid.Empty;
        }
        public Tasks(string title, string description, string priority, string status, DateTimeOffset dueDate, Guid employeeId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("Title cannot be null or empty.", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException("Description cannot be null or empty.", nameof(description));
            }
            if (string.IsNullOrWhiteSpace(priority))
            {
                throw new DomainException("Priority cannot be null or empty.", nameof(priority));
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new DomainException("Status cannot be null or empty.", nameof(status));
            }
            if (employeeId == Guid.Empty)
            {
                throw new DomainException("EmployeeId cannot be empty.", nameof(employeeId));
            }
            if (dueDate < DateTimeOffset.UtcNow)
            {
                throw new DomainException("DueDate cannot be in the past.", nameof(dueDate));
            }
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            DueDate = dueDate;
            CreateAt = DateTimeOffset.UtcNow;
            EmployeeId = employeeId;
        }
        public void Update(string title, string description, string priority, string status, DateTimeOffset dueDate, Guid employeeId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("Title cannot be null or empty.", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException("Description cannot be null or empty.", nameof(description));
            }
            if (string.IsNullOrWhiteSpace(priority))
            {
                throw new DomainException("Priority cannot be null or empty.", nameof(priority));
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new DomainException("Status cannot be null or empty.", nameof(status));
            }
            if (dueDate < DateTimeOffset.UtcNow)
            {
                throw new DomainException("DueDate cannot be in the past.", nameof(dueDate));
            }
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            DueDate = dueDate;
            EmployeeId = employeeId;
        }

    }
}
