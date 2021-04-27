namespace LoginNegocio.Tabelas
{
    public class TokensUsuario
    {
        private string esquema = "LGM";
        private long Id;
        private long TokenId;
        private long UsuarioId;

        public long codigo
        {
            get { return Id; }
            set { Id = value; }
        }
        public long tokenId
        {
            get { return TokenId; }
            set { TokenId = value; }
        }
        public long usuarioId
        {
            get { return UsuarioId; }
            set { UsuarioId = value; }
        }
        public Token Token { get; set; }
        public Usuario Usuario { get; set; }
    }
}