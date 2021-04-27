using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VMMapaNegocio.Tabelas;

namespace VMMapaNegocio
{
    /// <summary>
    /// Manipulador de procedimento voltados a Cidades
    /// </summary>
    public class ManipulaCidade : BancoDeDados
    {
        public Cidade Inclui(Cidade cidade)
        {
            List<FronteirasCidade> fronteirasCidades = new List<FronteirasCidade>();
            if (cidade.fronteirasCidade != null && cidade.fronteirasCidade.Count > 0)
            {
                fronteirasCidades = cidade.fronteirasCidade;
            }
            Cidade cidadeSalva = new Cidade();
            cidadeSalva = inclui.IncluiT<Cidade>(cidade, 2);
            if(cidadeSalva.codigo > 0 && fronteirasCidades.Count > 0)
            {
                foreach (FronteirasCidade fronteiraCidade in fronteirasCidades)
                {
                    fronteiraCidade.cidadeId = cidadeSalva.codigo;
                    inclui.IncluiT<FronteirasCidade>(fronteiraCidade, 2);
                }
            }
            return cidade;
        }
        public Cidade Altera(Cidade cidade)
        {
            if(cidade.fronteirasCidade != null && cidade.fronteirasCidade.Count > 0){
                foreach (FronteirasCidade fronteirasCidadeCorrente in cidade.fronteirasCidade)
                {
                    new ManipulaFronteirasCidade().Inclui(fronteirasCidadeCorrente);
                }
            }
            return altera.AlteraT<Cidade>(cidade, 2);
        }
        public Cidade Busca(long cidadeId)
        {
            return busca.BuscaT<Cidade>(new Cidade() { codigo = cidadeId }, 2);
        }
        public List<Cidade> Pesquisa(Cidade cidade)
        {
            List<Cidade> cidades = busca.PesquisaTodosT<Cidade>(cidade, 2);
            if(cidades.Count > 0)
            {
                if(cidade.nome != null && cidade.codigo == 0)
                {
                    cidades = cidades.Where(s => s.nome.Contains(cidade.nome)).ToList();
                }
                foreach (Cidade cidadeCorrente in cidades)
                {
                    cidadeCorrente.fronteirasCidade = busca.PesquisaT<FronteirasCidade>(new FronteirasCidade() { cidadeId = cidadeCorrente.codigo }, 2);
                    foreach (FronteirasCidade fronteirasCidadeCorrente in cidadeCorrente.fronteirasCidade)
                    {
                        fronteirasCidadeCorrente.fronteira = busca.BuscaT<Cidade>(new Cidade() { codigo = fronteirasCidadeCorrente.fronteiraId }, 2);
                    }
                }
                return cidades.ToList();
            }
            else
            {
                return new List<Cidade>();
            }
        }
        public bool Remove(FronteirasCidade fronteirasCidade)
        {
            List<FronteirasCidade> fronteirasCidades = busca.PesquisaT<FronteirasCidade>(fronteirasCidade, 2);
            foreach (FronteirasCidade fronteirasCidadeCorrente in fronteirasCidades)
            {
                remove.RemoveT<FronteirasCidade>(new FronteirasCidade() { codigo = fronteirasCidadeCorrente.codigo }, 2);
            }
            remove.RemoveT<Cidade>(new Cidade() { codigo = fronteirasCidade.cidadeId }, 2);
            return true;
        }
    }
}