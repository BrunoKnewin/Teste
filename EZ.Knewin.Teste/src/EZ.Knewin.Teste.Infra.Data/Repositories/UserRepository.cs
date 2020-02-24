using EZ.Knewin.Teste.Domain.Entities;
using EZ.Knewin.Teste.Domain.Interfaces;
using EZ.Knewin.Teste.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZ.Knewin.Teste.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly TesteDbContext context;

        public UserRepository(TesteDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> ObterPorUsuarioESenha(string username, string senha)
        {
            var users = new List<User>();
            users.Add(new User("admin", "admin", "manager"));
            
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }

    }
}
