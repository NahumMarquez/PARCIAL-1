using System.ComponentModel.DataAnnotations;

namespace parcial1.Models
{
    public class Faculties
    {
        public int FacultiesId { get; set; }

        [Required(ErrorMessage = "El nombre de la facultad es obligatorio.")]
        public string FacultyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo Creado por es obligatorio.")]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;

        public string? EditedBy { get; set; } // Puede ser nulo

        public DateTime? Edited { get; set; } // Puede ser nulo

        public bool IsActive { get; set; } = true; // Inicialización predeterminada
    }
}

