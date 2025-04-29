using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace javierArias_Ev1.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(40, ErrorMessage = "El nombre no puede tener más de 40 caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras en el nombre")]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }

        [Range(18, 100, ErrorMessage = "La edad debe estar entre 18 y 100.")]
        public int Edad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 10000, ErrorMessage = "El saldo debe estar entre 0 y 10000.")]
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido.")]
        public string Email { get; set; }

        [Display(Name = "¿Cliente activo?")]
        public bool EsActivo { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; }

        // Relaciones
        public virtual PlanDeRecompensa? PlanDeRecompensa { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}



