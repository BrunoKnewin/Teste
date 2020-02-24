using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        public UsuarioRepository() { }

        public async Task<Usuario> ObterPorUsuarioESenha(string username, string senha)
        {
            var users = new List<Usuario>();
            users.Add(new Usuario("admin", "admin", "manager"));
            users.Add(new Usuario("guest", "guest", "default"));

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Senha == senha).FirstOrDefault();
        }

    }
}
