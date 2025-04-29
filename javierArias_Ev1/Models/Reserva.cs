using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace javierArias_Ev1.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de entrada es obligatoria.")]
        public DateTime FechaEntrada { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de salida es obligatoria.")]
        [CustomValidation(typeof(Reserva), nameof(ValidarFechas))]
        public DateTime FechaSalida { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Debe indicar el valor a pagar.")]
        public decimal ValorAPagar { get; set; }

        // Relaciones
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public static ValidationResult? ValidarFechas(DateTime fechaSalida, ValidationContext context)
        {
            var instance = context.ObjectInstance as Reserva;
            if (instance != null && fechaSalida < instance.FechaEntrada)
            {
                return new ValidationResult("La fecha de salida debe ser posterior a la fecha de entrada.");
            }
            return ValidationResult.Success;
        }
    }
}




