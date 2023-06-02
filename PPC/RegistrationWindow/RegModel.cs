using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC
{
    public class RegModel 
    {
        public static Date_Users AddUser(string Login, string Password)
        {
            Users user = new Users();
            using (TheBestV2Entities db = new TheBestV2Entities())
            {
                db.Users.Add(user);
                Date_Users AuthUser = new Date_Users
                {
                    Login = Login,
                    Password = Password,
                    Users = user
                };
                db.Date_Users.Add(AuthUser);
                db.SaveChanges();
            }
            using (TheBestV2Entities db = new TheBestV2Entities())
            {
                return db.Date_Users.Find(Login);
            }
        }
        public static bool CheckLoginInSystem(string login)
        {
            using (TheBestV2Entities db = new TheBestV2Entities())
            {
                if (db.Date_Users.Where(a => a.Login == login).Count() > 0)
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
