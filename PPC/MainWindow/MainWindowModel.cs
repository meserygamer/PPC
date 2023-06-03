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
        /// <summary>
        /// Метод авторизации в системе
        /// </summary>
        /// <param name="Login">Введённый логин</param>
        /// <param name="Password">Введённый пароль</param>
        /// <returns>Запись о пользователе из БД (если пользователь не найден возвращается пустой конструктор)</returns>
        public static Date_Users AuthorizationInSystem(string Login, string Password)
        {
            List<Date_Users> Users;
            Date_Users User;
            using (TheBestV2Entities DB = new TheBestV2Entities())
            {
                Users = DB.Date_Users.Where(a => a.Login == Login && a.Password == Password).ToList();
                if (Users.Count != 0) User = Users.ToList().First();
                else User = new Date_Users();
                User.Users = User.Users;
                User.Role = User.Role;
                return User;
            }
        }
    }
}
