using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PPC
{
    public class Authorization
    {
        public static Date_Users AuthorizationInSystem(string Login, string Password)
        {
            List<Date_Users> Users;
            using (TheBestV2Entities DB = new TheBestV2Entities())
            {
                Users = DB.Date_Users.Where(a => a.Login == Login && a.Password == Password).ToList();
            }
            if(Users.Count != 0) return Users[0];
            else return new Date_Users();
        }
    }
}
