using Knewin.InfoCity.WebApi.Dal;
using Knewin.InfoCity.WebApi.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Knewin.InfoCity.WebApi.Service
{
    public class UserService
    {
        private DataContext dataContext;
        public UserService()
        {
            dataContext = new DataContext();
        }
        public User Find(string name, string password)
        {
            User user;
            try
            {
                user = dataContext.Users.Where(u => u.Name == name && u.Password == password).FirstOrDefault();
            }
            catch (Exception)
            {

                user = null;
            }
            return user;
        }
    }
}
