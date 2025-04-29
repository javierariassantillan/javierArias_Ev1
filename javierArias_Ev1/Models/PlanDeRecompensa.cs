using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace javierArias_Ev1.Models
{
    public class PlanDeRecompensa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del plan es obligatorio.")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Range(0, int.MaxValue)]
        public int PuntosAcumulados { get; set; }

        [NotMapped]
        public string TipoRecompensa
        {
            get
            {
                return PuntosAcumulados >= 500 ? "GOLD" : "SILVER";
            }
        }

        // Relaciones
        [Required]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }
    }
}







