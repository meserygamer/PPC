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
    }
}
