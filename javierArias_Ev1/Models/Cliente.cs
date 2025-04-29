using javierArias_Ev1.Models;
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
        public string AriasJ { get; set; } 

        [Range(18, 100, ErrorMessage = "La edad debe estar entre 18 y 100.")]
        public int Edad { get; set; } // Aquí está le campo tipo int

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 10000, ErrorMessage = "El saldo debe estar entre 0 y 10000.")]
        public decimal Saldo { get; set; } // Aquí esta el Campo tipo decimal

        [EmailAddress(ErrorMessage = "Por favor, debe ingresar un email válido.")]
        public string Email { get; set; } // Aquí esta el Campo tipo string

        public bool EsActivo { get; set; } // Aquí esta el Campo tipo bool

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateTime FechaRegistro { get; set; } // Aquí esta el Campo tipo fecha

        // Relaciones
        public virtual PlanRecompensa? PlanRecompensa { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }



}



