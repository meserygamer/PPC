using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
