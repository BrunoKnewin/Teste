using System.Collections.Generic;
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
            List<FronteirasCidade> fronteirasCidades = busca.PesquisaTodosT<FronteirasCidade>(new FronteirasCidade(), 2).ToList();
            List<FronteirasCidade> fronteirasCidadesFiltradas = BuscaFronteiras(cidadeA);
            int indice = fronteirasCidadesFiltradas.Count();
            
            foreach (FronteirasCidade fronteiraCidade in fronteirasCidadesFiltradas)
            {
                if(fronteiraCidade.fronteiraId == cidadeB.codigo || fronteiraCidade.cidadeId == cidadeB.codigo)
                {

                }
            }
            
            return new List<Cidade>();
        }
        private List<FronteirasCidade> BuscaFronteiras(Cidade cidade)
        {
            List<FronteirasCidade> fronteirasCidades = busca.PesquisaT<FronteirasCidade>(new FronteirasCidade() { cidadeId = cidade.codigo }, 2).ToList();
            fronteirasCidades.AddRange(busca.PesquisaT<FronteirasCidade>(new FronteirasCidade() { fronteiraId = cidade.codigo }, 2).ToList());
            return fronteirasCidades;
        }
    }
}