using Microsoft.EntityFrameworkCore;
using TurnoAgil.Models;

namespace TurnoAgil.Data{
    public class MisericordiaContext : DbContext{
        public MisericordiaContext (DbContextOptions<MisericordiaContext> options): base(options)
        {

        }
        public DbSet<Asesor> Asesores { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
}