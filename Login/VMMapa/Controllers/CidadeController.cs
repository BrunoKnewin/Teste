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
    public class CidadeController : ControllerBase
    {
        private readonly ILogger<CidadeController> _logger;
        public CidadeController(ILogger<CidadeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        [Route("IncluiCidade")]
        public Cidade IncluiCidade(Cidade cidade)
        {
            try
            {
                if(cidade.codigo > 0)
                {
                    return new ManipulaCidade().Altera(cidade);
                }
                return new ManipulaCidade().Inclui(cidade);
            }
            catch (Exception ex)
            {
                return cidade;
            }
        }
        [HttpPost]
        [Route("AlteraCidade")]
        public Cidade AlteraCidade(Cidade cidade)
        {
            try
            {
                return new ManipulaCidade().Altera(cidade);
            }
            catch (Exception ex)
            {
                return cidade;
            }
        }
        [HttpPost]
        [Route("PesquisaCidade")]
        public List<Cidade> PesquisaCidade(Cidade cidade)
        {
            try
            {
                return new ManipulaCidade().Pesquisa(cidade);
            }
            catch(Exception ex) 
            {
                return new List<Cidade>();
            }
        }
        [HttpPost]
        [Route("BuscaCidade")]
        public Cidade BuscaCidade(long cidadeId)
        {
            try
            {
                return new ManipulaCidade().Busca(cidadeId);
            }
            catch (Exception ex)
            {
                return new Cidade();
            }
        }

        [HttpPost]
        [Route("RemoveCidade")]
        public bool RemoveCidade(FronteirasCidade fronteirasCidade)
        {
            try
            {
                return new ManipulaCidade().Remove(fronteirasCidade); 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        [Route("PesquisaCaminho")]
        public List<Cidade> PesquisaCaminho(LigacaoCidades ligacaoCidades)
        {
            try
            {
                return new ManipulaFronteirasCidade().PesquisaCaminho(new Cidade() { codigo = ligacaoCidades.cidadeA }, new Cidade() { codigo = ligacaoCidades.cidadeB });
            }
            catch (Exception ex)
            {
                return new List<Cidade>();
            }
        }
    }
    public class LigacaoCidades
    {
        public long cidadeA { get; set; }
        public long cidadeB { get; set; }
    }
}