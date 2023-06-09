﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC
{
    public class RegModel 
    {
        /// <summary>
        /// Добавление пользователя в БД
        /// </summary>
        /// <param name="Login">Введённый логин</param>
        /// <param name="Password">Введённый пароль</param>
        /// <returns>Возращает строку пользователя из БД</returns>
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
                Date_Users User = db.Date_Users.Find(Login);
                User.Users = User.Users;
                User.Role = User.Role;
                return User;
            }
        }
        /// <summary>
        /// Проверка наличия введённого логина в системе
        /// </summary>
        /// <param name="login">Введённый логин</param>
        /// <returns>Возвращает результат проверки</returns>
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
