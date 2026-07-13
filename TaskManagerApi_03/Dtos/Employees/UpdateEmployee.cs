using System.ComponentModel.DataAnnotations;

namespace TaskManagerApi_03.Dtos.Employees
{
    public class UpdateEmployee
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El departamento es obligatorio.")]
        public string Department { get; set; }
    }
}
