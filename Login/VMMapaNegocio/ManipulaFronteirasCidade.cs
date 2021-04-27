﻿using System.Collections.Generic;
using System.Linq;
using VMMapaNegocio.Tabelas;

namespace VMMapaNegocio
{
    /// <summary>
    /// Manipulador de procedimento voltados a FronteirasCidades
    /// </summary>
    public class ManipulaFronteirasCidade : BancoDeDados
    {
        public FronteirasCidade Inclui(FronteirasCidade fronteirasCidade)
        {
            if (busca.PesquisaT<FronteirasCidade>(new FronteirasCidade() { cidadeId = fronteirasCidade.cidadeId, fronteiraId = fronteirasCidade.fronteiraId }, 2).Count == 0)
            {
                return inclui.IncluiT<FronteirasCidade>(fronteirasCidade, 2);
            }
            else
            {
                return fronteirasCidade;
            }
        }
        public FronteirasCidade Remove(FronteirasCidade fronteirasCidade)
        {
            return remove.RemoveT<FronteirasCidade>(fronteirasCidade, 2);
        }
        public List<FronteirasCidade> Pesquisa(FronteirasCidade fronteirasCidade)
        {
            return busca.PesquisaT<FronteirasCidade>(fronteirasCidade, 2).ToList();
        }
        public List<Cidade> PesquisaCaminho(Cidade cidadeA, Cidade cidadeB)
        {
            long cidadeinicio = cidadeA.codigo;
            long cidadefim = cidadeB.codigo;
            List<LigacaoCidades> todos = busca.PesquisaTodosT<FronteirasCidade>(new FronteirasCidade(), 2).Select(s => new LigacaoCidades() { CidadeA = s.cidadeId, CidadeB = s.fronteiraId }).OrderBy(s => s.CidadeA).ToList();
            List<LigacaoCidades> fronteirasCorrente = todos.Where(s => s.CidadeA == cidadeinicio || s.CidadeB == cidadeinicio).ToList();
            List<LigacaoCidades> caminhos = new List<LigacaoCidades>();

            bool encontrou = false;
            if (fronteirasCorrente.Where(s => s.CidadeA == cidadefim || s.CidadeB == cidadefim).Count() > 0)
            {
                caminhos.Add(new LigacaoCidades() { CidadeA = cidadeinicio, CidadeB = cidadefim });
                encontrou = true;
            }
            long indice = 0;
            while (!encontrou)
            {
                List<LigacaoCidades> fronteirasCarregamento = new List<LigacaoCidades>();
                foreach (LigacaoCidades ligacao in fronteirasCorrente)
                {
                    fronteirasCarregamento.AddRange(todos.Where(s => s.CidadeA == ligacao.CidadeA || s.CidadeB == ligacao.CidadeA));
                    fronteirasCarregamento.AddRange(todos.Where(s => s.CidadeB == ligacao.CidadeB || s.CidadeA == ligacao.CidadeB));
                    fronteirasCarregamento = fronteirasCarregamento.Distinct().ToList();
                    if (fronteirasCarregamento.Where(s => s.CidadeA == cidadefim || s.CidadeB == cidadefim).Count() > 0)
                    {
                        encontrou = true;
                        caminhos.Add(ligacao);
                        caminhos.Add(fronteirasCarregamento.Where(s => s.CidadeA == cidadefim || s.CidadeB == cidadefim).First());
                    }
                    else if (caminhos.Where(s => s.CidadeA == ligacao.CidadeA && s.CidadeB == ligacao.CidadeB).Count() == 0
                            || caminhos.Where(s => s.CidadeA == ligacao.CidadeB && s.CidadeB == ligacao.CidadeA).Count() == 0)
                    {
                        caminhos.Add(ligacao);
                    }
                }
                if (caminhos.Last().CidadeA == cidadefim || caminhos.Last().CidadeB == cidadefim)
                {
                    break;
                }
                if (fronteirasCarregamento.Count() > 0)
                {
                    fronteirasCorrente = fronteirasCarregamento.Distinct().ToList();
                }
                else
                {
                    break;
                }
            }
            List<LigacaoCidades> caminhoEscolhido = new List<LigacaoCidades>();
            long proximo = cidadefim;
            foreach (LigacaoCidades ligacaoCidades in caminhos.Distinct())
            {
                if (ligacaoCidades.CidadeA == cidadeinicio && caminhoEscolhido.Count == 0)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                }
                else if (ligacaoCidades.CidadeB == cidadeinicio && caminhoEscolhido.Count == 0)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeB, CidadeB = ligacaoCidades.CidadeA });
                }
                else if (ligacaoCidades.CidadeA == caminhoEscolhido.Last().CidadeB)
                {
                    if (caminhos.Where(s => s.CidadeA == ligacaoCidades.CidadeB || s.CidadeA == ligacaoCidades.CidadeB).Count() > 1)
                    {
                        caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                    }
                }
                else if (ligacaoCidades.CidadeA == caminhoEscolhido.Last().CidadeB && caminhos.Where(s => s.CidadeA == ligacaoCidades.CidadeB || s.CidadeA == ligacaoCidades.CidadeB).Count() > 1)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                }
                else if (caminhos.Where(s => s.CidadeA == ligacaoCidades.CidadeB || s.CidadeA == ligacaoCidades.CidadeB).Count() > 1)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                }
                else if (ligacaoCidades.CidadeA == cidadefim)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = caminhoEscolhido.Last().CidadeB, CidadeB = ligacaoCidades.CidadeA });
                }

                if (ligacaoCidades.CidadeB == cidadefim)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = caminhoEscolhido.Last().CidadeB, CidadeB = ligacaoCidades.CidadeB });
                }
            }

            List<Cidade> cidadesNaOrdem = new List<Cidade>();

            foreach (LigacaoCidades cidade in caminhoEscolhido)
            {
                cidadesNaOrdem.Add(busca.BuscaT<Cidade>(new Cidade() { codigo = cidade.CidadeA }, 2));
                cidadesNaOrdem.Add(busca.BuscaT<Cidade>(new Cidade() { codigo = cidade.CidadeB }, 2));
            }
            return cidadesNaOrdem;
        }
        List<LigacaoCidades> RetornaFronteirasDeLista(long cidadeCodigo, List<LigacaoCidades> ligacaoCidades)
        {
            return ligacaoCidades.Where(s => s.CidadeA == cidadeCodigo || s.CidadeB == cidadeCodigo).ToList();
        }
    }
    class LigacaoCidades
    {
        public long CidadeA { get; set; }
        public long CidadeB { get; set; }
    }
}