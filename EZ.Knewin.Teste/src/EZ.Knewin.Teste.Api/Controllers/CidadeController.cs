using EZ.Knewin.Teste.Service.Dtos;
using EZ.Knewin.Teste.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Api.Controllers
{
    [Route("api/cidade")]
    [ApiController]
    public class CidadeController : Controller
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromServices] IArmazenadorDeCidade armazenadorDeCidade, [FromBody] CidadeDto cidadeDto)
        {
            if (cidadeDto == null) return BadRequest();

            var resultado = await armazenadorDeCidade.Armazenar(cidadeDto);

            return Ok(resultado);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IBuscadorDeCidade buscadorDeCidade) 
        {
            var cidades = await buscadorDeCidade.ObterTodas();

            if (cidades == null) return BadRequest("Nenhuma cidade encontrada.");

            return Ok(cidades);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] IBuscadorDeCidade buscadorDeCidade, int id)
        {
            var cidade = await buscadorDeCidade.ObterPorId(id);

            if (cidade == null) return BadRequest("Cidade não encontrada!");

            return Ok(cidade);
        }

        [Authorize]
        [HttpGet("{id}/fronteiras")]
        public async Task<IActionResult> GetFronteiras([FromServices] IBuscadorDeCidade buscadorDeCidade, int id)
        {
            var cidades = await buscadorDeCidade.ObterFronteirasPorCidadeId(id);

            if (cidades == null) return BadRequest("Cidades Fronteira não foram encontradas!");

            return Ok(cidades);
        }

        [Authorize]
        [HttpGet("total-de-habitantes")]
        public async Task<IActionResult> GetTotalDeHabitantes([FromServices] IBuscadorDeCidade buscadorDeCidade, [FromQuery] int[] ids)
        {
            var total = await buscadorDeCidade.ObterTotalDeHabitantesPorCidades(ids);

            if (total == 0) return BadRequest("Valores não contabilizados.");

            return Ok(total);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromServices] IAtualizadorDeCidade atualizadorDeCidade, [FromBody] CidadeDto cidadeDto)
        {
            var cidade = atualizadorDeCidade.Atualizar(cidadeDto);

            if (cidade == null) return BadRequest("Ocorreu um problema ao atualizar.");

            return Ok(cidade);
        }
    }
}