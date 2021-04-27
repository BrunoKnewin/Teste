using System;

namespace LoginNegocio.Tabelas
{
    public class Usuario
    {
        private string esquema = "LGM";
        private long Id;
        private string Login;
        private string Senha;
        private DateTime? DataUltimaAlteracao;
        public long codigo
        {
            get { return Id; }
            set { Id = value; }
        }
        public string nome
        {
            get { return Login; }
            set { Login = value; }
        }
        public string senha
        {
            get { return Senha; }
            set { Senha = value; }
        }
        public string palavra { get; set; }
        public DateTime? dataUltimaAlteracao
        {
            get { return DataUltimaAlteracao; }
            set { DataUltimaAlteracao = value; }
        }
        public Token token { get; set; }
    }
}