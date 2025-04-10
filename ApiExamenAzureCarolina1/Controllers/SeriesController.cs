using ApiExamenAzureCarolina1.Models;
using ApiExamenAzureCarolina1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenAzureCarolina1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;

        public SeriesController (RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> FindSerie(int id)
        {
            return await this.repo.FindSerieAsync(id);
        }

        [HttpGet("{idserie}/personajes")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSerie(int idserie)
        {

            return await this.repo.GetPersonajesBySerieAsync(idserie);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Personaje>>> MultiplesPersonajeSerie([FromQuery] List<int> idsseries)
        {
            return await this.repo.GetPersonjesBySeriessAsync(idsseries);
        }
    }
}
