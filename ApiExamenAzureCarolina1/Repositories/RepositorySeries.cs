using ApiExamenAzureCarolina1.Data;
using ApiExamenAzureCarolina1.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenAzureCarolina1.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FindSerieAsync(int idSerie)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == idSerie);
        }

        public async Task<List<Personaje>> GetPersonajesBySerieAsync(int idSerie)
        {
            return await this.context.Personajes.Where(z => z.IdSerie == idSerie).ToListAsync();
        }

        public async Task UpdatePersonajeSerie(int idPersonaje, string nombre, string imagen, int idSerie)
        {
            Personaje personaje = await this.context.Personajes.FindAsync(idPersonaje);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            personaje.IdSerie = idSerie;
            await this.context.SaveChangesAsync();
        }

        public async Task<List<Personaje>> GetPersonjesBySeriessAsync(List<int> idsSeries)
        {
            var consulta = from datos in this.context.Personajes where idsSeries.Contains(datos.IdSerie) select datos;
            return await consulta.ToListAsync();
        }
    }
}

