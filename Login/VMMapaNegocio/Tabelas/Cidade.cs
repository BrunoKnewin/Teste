using System.Collections.Generic;

namespace VMMapaNegocio.Tabelas
{
    public class Cidade
    {
        private string esquema = "FN";
        private long Id;
        private string Nome;
        private long Habitantes;

        public long codigo
        {
            get { return Id; }
            set { Id = value; }
        }
        public string nome
        {
            get { return Nome; }
            set { Nome = value; }
        }
        public long habitantes 
        {
            get { return Habitantes; }
            set { Habitantes = value; }
        }
        public List<FronteirasCidade> fronteirasCidade { get; set; }
    }
}