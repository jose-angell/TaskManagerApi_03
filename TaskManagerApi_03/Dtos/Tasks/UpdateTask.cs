using System.ComponentModel.DataAnnotations;
using TaskManagerApi_03.Domain;

namespace TaskManagerApi_03.Dtos.Tasks
{
    public class UpdateTask
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        public string Priority { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTimeOffset DueDate { get; set; }
        [Required(ErrorMessage = "El ID del empleado es obligatorio.")]
        public Guid EmployeeId { get; set; }
    }
}
