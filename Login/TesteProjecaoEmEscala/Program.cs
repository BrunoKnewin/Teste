using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteProjecaoEmEscala
{
    class Program
    {
        static void Main(string[] args)
        {
            long cidadeinicio = 1;
            long cidadefim = 8;
            List<LigacaoCidades> todos = Todos();
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
                    Visualisa(fronteirasCarregamento);
                    if (fronteirasCarregamento.Where(s => s.CidadeA == cidadefim || s.CidadeB == cidadefim).Count() > 0)
                    {
                        encontrou = true;
                        caminhos.Add(ligacao);
                        caminhos.Add(fronteirasCarregamento.Where(s => s.CidadeA == cidadefim || s.CidadeB == cidadefim).First());
                    }
                    else if (  caminhos.Where(s => s.CidadeA == ligacao.CidadeA && s.CidadeB == ligacao.CidadeB).Count() == 0
                            || caminhos.Where(s => s.CidadeA == ligacao.CidadeB && s.CidadeB == ligacao.CidadeA).Count() == 0)
                    {
                        caminhos.Add(ligacao);
                    }
                }
                if(caminhos.Last().CidadeA == cidadefim || caminhos.Last().CidadeB == cidadefim)
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
            Visualisa(caminhos.Distinct().ToList());
            foreach (LigacaoCidades ligacaoCidades in caminhos.Distinct())
            {
                if (ligacaoCidades.CidadeA == cidadeinicio && caminhoEscolhido.Count == 0)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                }
                else if (ligacaoCidades.CidadeB == cidadeinicio &&  caminhoEscolhido.Count == 0)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeB, CidadeB = ligacaoCidades.CidadeA });
                }
                else if (ligacaoCidades.CidadeA == caminhoEscolhido.Last().CidadeB)
                {
                    if(caminhos.Where(s => s.CidadeA == ligacaoCidades.CidadeB || s.CidadeA == ligacaoCidades.CidadeB).Count() > 1)
                    {
                        caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                    }
                }
                else if (ligacaoCidades.CidadeA == caminhoEscolhido.Last().CidadeB && caminhos.Where(s=> s.CidadeA == ligacaoCidades.CidadeB || s.CidadeA == ligacaoCidades.CidadeB).Count() > 1)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                }
                else if(caminhos.Where(s => s.CidadeA == ligacaoCidades.CidadeB || s.CidadeA == ligacaoCidades.CidadeB).Count() > 1)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = ligacaoCidades.CidadeA, CidadeB = ligacaoCidades.CidadeB });
                }
                else if (ligacaoCidades.CidadeA == cidadefim)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = caminhoEscolhido.Last().CidadeB, CidadeB = ligacaoCidades.CidadeA});
                }
                
                if (ligacaoCidades.CidadeB == cidadefim)
                {
                    caminhoEscolhido.Add(new LigacaoCidades() { CidadeA = caminhoEscolhido.Last().CidadeB, CidadeB = ligacaoCidades.CidadeB });
                }
                Visualisa(caminhoEscolhido);
            }
            Visualisa(caminhoEscolhido);
        }
        public static void Visualisa(List<LigacaoCidades> ligacaoCidades)
        {

            Console.WriteLine("-- INICIO --");
            foreach (LigacaoCidades ligacao in ligacaoCidades)
            {
                Console.WriteLine($"ligação A:{ligacao.CidadeA} - B:{ligacao.CidadeB}");
            }
            Console.WriteLine("-- FINAL --");
        }
        public static List<LigacaoCidades> Todos()
        {
            List<LigacaoCidades> ligacaoCidades = new List<LigacaoCidades>();
            ligacaoCidades.Add(new LigacaoCidades()
            {
               CidadeA=1,
               CidadeB=2
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 1,
                CidadeB = 3
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 1,
                CidadeB = 5
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 1,
                CidadeB = 7
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 1,
                CidadeB = 9
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 2,
                CidadeB = 4
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 4,
                CidadeB = 7
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 5,
                CidadeB = 6
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 7,
                CidadeB = 8
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 9,
                CidadeB = 10
            });
            ligacaoCidades.Add(new LigacaoCidades()
            {
                CidadeA = 9,
                CidadeB = 11
            });
            return ligacaoCidades;
        }
    }
    class LigacaoCidades
    {
        public long CidadeA { get; set; }
        public long CidadeB { get; set; }
    }
}
