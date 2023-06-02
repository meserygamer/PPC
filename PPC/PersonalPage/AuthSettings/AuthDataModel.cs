using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace PPC.PersonalPage
{
    public enum StateSettings
    {
        SettingsNotChanged,
        SettingsChanged,
    }
    public class AuthDataModel
    {
        public static bool CheckEmail(string email)
        {
            return Regex.IsMatch(email, @"^.{3,20}@.{3,20}\..{2,7}$");
        }
        public static bool CheckPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*[0-9])[A-z0-9]{6,}$");
        }
        public static bool CheckPasswordOnEquals(string oldPassword, string newPassword)
        {
            return oldPassword == newPassword;
        }
        public static void ChangeAuthData(int Id_user, string Password, string Email)
        {
            using(TheBestV2Entities DB = new TheBestV2Entities())
            {
                Date_Users user = DB.Date_Users.Where(a => a.ID_user == Id_user).First();
                user.Users.Email = Email;
                user.Password = Password;
                DB.SaveChanges();
                Application.Current.Resources["UserData"] = DB.Date_Users.Where(a => a.ID_user == Id_user).First();
            }
        }
        public static void ChangeAuthData(string Email, int Id_user)
        {
            using (TheBestV2Entities DB = new TheBestV2Entities())
            {
                Date_Users user = DB.Date_Users.Where(a => a.ID_user == Id_user).First();
                user.Users.Email = Email;
                DB.SaveChanges();
                Application.Current.Resources["UserData"] = DB.Date_Users.Where(a => a.ID_user == Id_user).First();
            }
        }
    }
}
