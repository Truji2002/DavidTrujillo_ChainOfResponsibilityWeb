using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DavidTrujillo_EjercicioCF.Models;

namespace DavidTrujillo_EjercicioCF.Data
{
    public class DavidTrujillo_EjercicioCFContext : DbContext
    {
        public DavidTrujillo_EjercicioCFContext (DbContextOptions<DavidTrujillo_EjercicioCFContext> options)
            : base(options)
        {
        }

      
        public DbSet<DavidTrujillo_EjercicioCF.Models.Sanduche> Sanduche { get; set; }
    }
}
