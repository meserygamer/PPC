using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;

namespace PPC.PersonalPage
{
    public class BasicModel
    {
        public static bool FioOnEmpty(string Surname, string Name, string Patronymic)
        {
            if(Surname == null || Name == null || Patronymic == null || Surname == "" || Name == "" || Patronymic == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool NumCheck(string Phone)
        {
            Regex r = new Regex(@"^7\([0-9]{3}\)[0-9]{3}\-[0-9]{2}\-[0-9]{2}$");
            return r.IsMatch(Phone);
        }
        public static void ChangeFIO(string Name, string Surname, string Patronymic, string Phone)
        {
            using(TheBestV2Entities DB = new TheBestV2Entities())
            {
                Date_Users User = DB.Date_Users.Find(((Date_Users)Application.Current.FindResource("UserData")).Login);
                User.Users.Name = Name;
                User.Users.Phone = Phone;
                User.Users.Surname = Surname;
                User.Users.Patronymic = Patronymic;
                Application.Current.Resources["UserData"] = User;
                DB.SaveChanges();
            }
        }
    }
}
