using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using javierArias_Ev1.Models;

namespace javierArias_Ev1.Data
{
    public class javierArias_Ev1Context : DbContext
    {
        public javierArias_Ev1Context (DbContextOptions<javierArias_Ev1Context> options)
            : base(options)
        {
        }

        public DbSet<javierArias_Ev1.Models.Cliente> Cliente { get; set; } = default!;
    }
}
