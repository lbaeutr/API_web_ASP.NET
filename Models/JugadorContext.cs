using Microsoft.EntityFrameworkCore;

namespace api_psp.Models
{
    public class JugadorContext : DbContext
    {
        public JugadorContext(DbContextOptions<JugadorContext> options)
            : base(options)
        { }

        public DbSet<Jugador> Jugadores { get; set; }
    }
}



