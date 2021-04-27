using System;

namespace LoginNegocio.Tabelas
{
    public class Token
    {
        private string esquema = "LGM";
        private long Id;
        private string CodigoToken;
        private DateTime DataSecao;
        private bool Ativo;

        public long codigo
        {
            get { return Id; }
            set { Id = value; }
        }
        public string codigoToken
        {
            get { return CodigoToken; }
            set { CodigoToken = value; }
        }
        public DateTime dataSecao
        {
            get { return DataSecao; }
            set { DataSecao = value; }
        }
        public bool ativo
        {
            get { return Ativo; }
            set { Ativo = value; }
        }
    }
}