using Cidades.Application.Interfaces;
using Cidades.Application.ViewModels.Common;
using Cidades.Application.ViewModels.Request;
using Cidades.Application.ViewModels.Response;
using Cidades.Domain.Containers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CidadesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeAppService _cidadeAppService;

        public CidadeController(ICidadeAppService cidadeAppService)
        {
            _cidadeAppService = cidadeAppService;
        }

        [HttpGet("PopularBanco")]
        [AllowAnonymous]
        public IActionResult PopularBanco()
        {
            _cidadeAppService.PopularBanco();
            return Ok("Cidades cadastradas");
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _cidadeAppService.GetAll();

                if (!result.IsValid())
                {
                    return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Sem cidades para exibir!" }));
                }

                return Ok(new RequestResult<IEnumerable<ListCidadeResponseViewModel>>(200, result.List));
            }
            catch (Exception)
            {
                return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao listar as cidades" }));
            }
        }

        [Authorize]
        [HttpGet("GetByNome")]
        public IActionResult GetByNome(string nome)
        {
            try
            {
                var result = _cidadeAppService.GetByName(nome);

                if (!result.IsValid())
                {
                    return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Cidade não encontrada!" }));
                }

                return Ok(new RequestResult<ListCidadeResponseViewModel>(200, result));
            }
            catch (Exception)
            {
                return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao procurar a cidade" }));
            }
        }

        [Authorize]
        [HttpGet("FazemFonteirasCom")]
        public IActionResult FazemFonteirasCom(string cidade)
        {
            try
            {
                var result = _cidadeAppService.FazemFronteirasCom(cidade);

                if (result.Count < 1)
                {
                    return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Sem cidades para exibir!" }));
                }

                return Ok(new RequestResult<IEnumerable<ListCidadeResponseViewModel>>(200, result));
            }
            catch (Exception)
            {
                return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao listar as cidades" }));
            }
        }

        [Authorize]
        [HttpPost("Save")]
        public IActionResult Save([FromBody] AddCidadeRequestViewModel model)
        {
            try
            {
                var result = _cidadeAppService.Save(model);

                if (!result.IsValid())
                {
                    return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { result.Messages[0] }));
                }

                return Ok("Cidade cadastrada com sucesso!");
            }
            catch (Exception)
            {
                return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao cadastrar a cidade" }));
            }
        }

        [Authorize]
        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateCidadeRequestViewModel model)
        {
            try
            {
                var result = _cidadeAppService.Update(model);

                if (!result.IsValid())
                {
                    return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { result.Messages[0] }));
                }

                return Ok("Cidade atualziada com sucesso!");
            }
            catch (Exception)
            {
                return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao atualizar a cidade" }));
            }
        }

        [Authorize]
        [HttpGet("CalcularPopulacao")]
        public IActionResult CalcularPopulacao(List<string> cidades)
        {
            try
            {
                var result = _cidadeAppService.CalcularPopulacao(cidades);

                return Ok(new RequestResult<double>(200, result));
            }
            catch (Exception)
            {
                return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao listar as cidades" }));
            }
        }
    }
}