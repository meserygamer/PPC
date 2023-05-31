using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
    }
}
