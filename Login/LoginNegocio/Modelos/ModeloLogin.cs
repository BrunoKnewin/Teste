namespace LoginNegocio.ModeloDeDados
{
    public class ModeloLogin
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string TokenAtual { get; set; }
        public string Localidade { get; set; }
        public string DataAcesso { get; set; }
        public string Palavra { get; set; }
    }
}