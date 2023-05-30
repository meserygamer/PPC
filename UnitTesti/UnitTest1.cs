using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PPC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()//Проверяет возращает ли метод проверки заполнения логина False, при заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.Login = "123";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test2()//Проверяет возращает ли метод проверки заполнения логина True, при не заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.Login = "";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test3()//Проверяет возращает ли метод проверки заполнения логина не пустое значение
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.Login = "";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Test4()//Проверяет возращает ли метод проверки заполнения пароля False, при заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.password = "123";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test5()//Проверяет возращает ли метод проверки заполнения пароля True, при не заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.password = "";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test6()//Проверяет возращает ли метод проверки заполнения пароля не пустое значение
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.password = "";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Test7()//Проверяет будет ли результат метода на проверку наличия пользователя в системе True при пустых полях
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.User = new Date_Users();
            bool result = obj.CheckOnFailAuthorization();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test8()//Проверяет будет ли результат метода на проверку наличия пользователя в системе Flase при заполненных полях
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.User = new Date_Users {ID_user = 1};
            bool result = obj.CheckOnFailAuthorization();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test9()//Проверяет возращает ли метод проверки наличия пользователя в системе не пустое значение
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            bool result = obj.CheckOnFailAuthorization();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test10()//Проверяет возвращает ли метод проверки соответствия паролей значние True, при совпадающих паролях
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "123";
            obj.ConfirmPassword = "123";
            bool result = obj.CheckPassword_Confirm();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test11()//Проверяет возварщает ли метод проверки соответсвия паролей значение False, при несовпадающих паролях
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "123";
            obj.ConfirmPassword = "321";
            bool result = obj.CheckPassword_Confirm();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test12()//Проверяет возварщает ли метод проверки соответсвия пароля маске значение False, при неккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "123";
            bool result = obj.PasswordCheck();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test13()//Проверяет возварщает ли метод проверки соответсвия пароля маске значение True, при ккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "A1b2c3";
            bool result = obj.PasswordCheck();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test14()//Проверяет возварщает ли метод проверки соответсвия логина маске значение False, при неккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "123";
            bool result = obj.LoginCheck();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test15()//Проверяет возварщает ли метод проверки соответсвия логина маске значение True, при ккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "Test";
            bool result = obj.LoginCheck();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test16()//Проверяет возварщает ли метод проверки логина на заполненность True, при пустом поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test17()//Проверяет возварщает ли метод проверки логина на заполненность True, при значении поля Null
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = null;
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test18()//Проверяет возварщает ли метод проверки логина на заполненность False, при заполненном поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "Test";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Test19()//Проверяет возварщает ли метод проверки пароля на заполненность True, при пустом поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test20()//Проверяет возварщает ли метод проверки пароля на заполненность True, при значении поля Null
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = null;
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Test21()//Проверяет возварщает ли метод проверки пароля на заполненность False, при заполненном поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "Test";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsFalse(result);
        }
    }
}
