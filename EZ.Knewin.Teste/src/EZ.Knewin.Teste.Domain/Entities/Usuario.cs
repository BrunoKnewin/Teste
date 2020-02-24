using System.ComponentModel.DataAnnotations;

namespace EZ.Knewin.Teste.Domain.Entities
{
    public class Usuario : Entity<int>
    {
        [Required(ErrorMessage = "Username é obrigatório!")]
        public string Username { get; private set; }

        [Required(ErrorMessage = "Senha é obrigatória!")]
        public string Senha { get; private set; }
        public string Perfil { get; private set; }

        public Usuario() { }

        public Usuario(string username, string senha, string perfil = "default")
        {
            this.Username = username;
            this.Senha = senha;
            this.Perfil = perfil;
        }

        public void AlterarUsername(string username)
        {
            this.Username = username;
        }

        public void AlterarSenha(string senha)
        {
            this.Senha = senha;
        }
    }
}
