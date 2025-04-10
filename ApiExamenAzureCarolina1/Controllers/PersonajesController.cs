using ApiExamenAzureCarolina1.Models;
using ApiExamenAzureCarolina1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenAzureCarolina1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repo;

        public PersonajesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpPut]
        [Route("[action]/{idpersonaje}/{idserie}/")]
        public async Task<IActionResult> UpdatePersonajeSerie(int idpersonaje, int idserie, Personaje p)
        {
            await this.repo.UpdatePersonajeSerie(idpersonaje, p.Nombre, p.Imagen, idserie);
            return Ok();
        }
    }
}
