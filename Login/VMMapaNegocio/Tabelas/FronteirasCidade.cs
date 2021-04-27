namespace VMMapaNegocio.Tabelas
{
    public class FronteirasCidade
    {
        private string esquema = "FN";
        private long Id;
        private long CidadeId;
        private long FronteiraId;
        public long codigo
        {
            get { return Id; }
            set { Id = value; }
        }
        public long cidadeId
        {
            get { return CidadeId; }
            set { CidadeId = value; }
        }
        public long fronteiraId
        {
            get { return FronteiraId; }
            set { FronteiraId = value; }
        }
        public Cidade fronteira { get; set; }
    }
}