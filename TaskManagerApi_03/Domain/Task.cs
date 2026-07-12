namespace TaskManagerApi_03.Domain
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Priority { get; private set; }
        public string Status { get; private set; }
        public DateTimeOffset DueDate { get; private set; }
        public DateTimeOffset CreateAt { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Employee? Employee { get; set; } 
        private Task()
        {
            Title = string.Empty;
            Description = string.Empty;
            Priority = string.Empty;
            Status = string.Empty;
            EmployeeId = Guid.Empty;
        }
        public Task(string title, string description, string priority, string status, DateTimeOffset dueDate, Guid employeeId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }
            if (string.IsNullOrWhiteSpace(priority))
            {
                throw new ArgumentException("Priority cannot be null or empty.", nameof(priority));
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status cannot be null or empty.", nameof(status));
            }
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentException("EmployeeId cannot be empty.", nameof(employeeId));
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
        public void Update(string title, string description, string priority, string status, DateTimeOffset dueDate)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }
            if (string.IsNullOrWhiteSpace(priority))
            {
                throw new ArgumentException("Priority cannot be null or empty.", nameof(priority));
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status cannot be null or empty.", nameof(status));
            }
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            DueDate = dueDate;
        }

    }
}
