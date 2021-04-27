using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using VMMapaNegocio;
using VMMapaNegocio.Tabelas;

namespace VMMapa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FronteiraController : ControllerBase
    {
        private readonly ILogger<FronteiraController> _logger;
        public FronteiraController(ILogger<FronteiraController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("IncluiFronteirasCidade")]
        public FronteirasCidade IncluiFronteirasCidade(FronteirasCidade fronteirasCidade)
        {
            try
            {
                return new ManipulaFronteirasCidade().Inclui(fronteirasCidade);
            }
            catch (Exception ex)
            {
                return fronteirasCidade;
            }
        }
        [HttpPost]
        [Route("RemoveFronteirasCidade")]
        public FronteirasCidade RemoveFronteirasCidade(FronteirasCidade fronteirasCidade)
        {
            try
            {
                return new ManipulaFronteirasCidade().Remove(fronteirasCidade);
            }
            catch (Exception ex)
            {
                return new FronteirasCidade();
            }
        }
        [HttpPost]
        [Route("PesquisaFronteirasCidade")]
        public List<FronteirasCidade> PesquisaFronteirasCidade(FronteirasCidade fronteira)
        {
            try
            {
                return new ManipulaFronteirasCidade().Pesquisa(fronteira);
            }
            catch(Exception ex) 
            {
                return new List<FronteirasCidade>();
            }
        }
        
    }
    
}