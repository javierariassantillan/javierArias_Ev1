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
        public DateTime FechaSalida { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Debe indicar el valor a pagar.")]
        public decimal ValorAPagar { get; set; }

        // Relaciones
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }


}




