using ApiExamenAzureCarolina1.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenAzureCarolina1.Data
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
