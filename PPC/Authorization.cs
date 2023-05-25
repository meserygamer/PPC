using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PPC
{
    public class Authtorization
    {
        private static Authtorization instance;
        private string login;
        private string password;
        public string Login
        {
            set { login = value; }
        }
        public string Password
        {
            set { password = value; }
        }
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
        public Date_Users Authorization()
        {
            using (UserContext db = new UserContext())
            {
                if (db.Date_Users.Where(a => a.Password == password && a.Login == login).Count() == 0)
                {
                    return new Date_Users();
                }
                else
                {
                    return db.Date_Users.Where(a => a.Password == password && a.Login == login).First();
                }
            }
        }
    }
}
