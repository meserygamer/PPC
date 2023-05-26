using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC
{
    public class Authtorization
    {
        private static Authtorization instance;
        public string login;
        public string password;
        private Authtorization()
        {
            login = "";
            password = "";
        }
        public static Authtorization GetAuthorization()
        {
            if (instance == null)
            {
                instance = new Authtorization();
                return instance;
            }
            else
            {
                return instance;
            }
        }
        public Date_Users Authorization(List<Date_Users> Data)
        {
            foreach (Date_Users user in Data)
            {
                if ((user.Login == login) && (user.Password == password))
                {
                    return user;
                }
            }
            return new Date_Users();
        }
    }
}
