using TaskManagerApi_03.Domain.Exceptions;

namespace TaskManagerApi_03.Domain
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Department { get; private set; }
        public bool IsActive { get; private set; }
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
        private Employee()
        {
            Name = string.Empty;
            Email = string.Empty;
            Department = string.Empty;
        }
        public Employee(string name, string email, string department)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name cannot be null or empty.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("Email cannot be null or empty.", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new DomainException("Department cannot be null or empty.", nameof(department));
            }
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Department = department;
            IsActive = true;
        }
        public void Update(string name, string email, string department, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("Name cannot be null or empty.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("Email cannot be null or empty.", nameof(email));
            }
            if (string.IsNullOrWhiteSpace(department))
            {
                throw new DomainException("Department cannot be null or empty.", nameof(department));
            }
            Name = name;
            Email = email;
            Department = department;
            IsActive = isActive;
        }
    }
}
