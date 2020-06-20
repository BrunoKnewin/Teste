using System.ComponentModel.DataAnnotations;

namespace EZ.Knewin.Teste.Domain.Entities
{
    public class Estado : Entity<int>
    {
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; private set; }
        [Required(ErrorMessage = "Sigla é obrigatória!")]
        public string Sigla { get; private set; }

        protected Estado() { }

        public void AlterarNome(string nome)
        {
            this.Nome = nome;
        }

        public void AlterarSigla(string sigla)
        {
            this.Sigla = sigla;
        }
    }
}
