using EZ.Knewin.Teste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Api.Controllers
{
    [Route("api/estado")]
    [ApiController]
    #pragma warning disable 1591
    public class EstadoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IBuscadorDeEstado buscadorDeEstado)
        {
            var estados = await buscadorDeEstado.BuscarTodos();

            if (estados == null) return BadRequest("Nenhum estado encontrado!");

            return Ok(estados);
        }
    }
}
