using Microsoft.EntityFrameworkCore;
using javierArias_Ev1.Models;

namespace javierArias_Ev1.Data
{
    public class javierArias_Ev1Context : DbContext
    {
        public javierArias_Ev1Context(DbContextOptions<javierArias_Ev1Context> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Reserva> Reserva { get; set; } = default!;
        public DbSet<PlanDeRecompensa> PlanDeRecompensa { get; set; } = default!;
    }
}

