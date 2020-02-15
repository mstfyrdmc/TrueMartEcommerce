using Model.Entities;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Option
{
   public class AppUserService : BaseService<AppUser>
    {
        public bool CheckCredentials(string username, string password)
        {
            return Any(x => x.UserName == username && x.Password == password);
        }

        public AppUser FindByUsername(string username)
        {
            return GetByDefault(x => x.UserName == username);
        }
    }
}
