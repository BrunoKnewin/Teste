using System.ComponentModel.DataAnnotations;

namespace EZ.Knewin.Teste.Domain.Entities
{
    public class User : Entity<int>
    {
        [Required(ErrorMessage = "Username é obrigatório!")]
        public string Username { get; private set; }

        [Required(ErrorMessage = "Password é obrigatório!")]
        public string Password { get; private set; }
        public string Role { get; private set; }

        public User() { }

        public User(string username, string password, string role = "default")
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }

        public void AlterarUsername(string username)
        {
            this.Username = username;
        }

        public void AlterarPassword(string password)
        {
            this.Password = password;
        }
    }
}
