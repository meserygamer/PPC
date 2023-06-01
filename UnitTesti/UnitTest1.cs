using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PPC.PersonalPage;

namespace PPC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoginOnEmptyFill()//Проверяет возращает ли метод проверки заполнения логина False, при заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.Login = "123";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestLoginOnEmptyEmpty()//Проверяет возращает ли метод проверки заполнения логина True, при не заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.Login = "";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestLoginOnEmptyNotNull()//Проверяет возращает ли метод проверки заполнения логина не пустое значение
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.Login = "";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestPasswordOnEmptyFill()//Проверяет возращает ли метод проверки заполнения пароля False, при заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.password = "123";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestPasswordOnEmptyEmpty()//Проверяет возращает ли метод проверки заполнения пароля True, при не заполненном поле
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.password = "";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestPasswordOnEmptyNotNull()//Проверяет возращает ли метод проверки заполнения пароля не пустое значение
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.password = "";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestUserInSystemEmpty()//Проверяет будет ли результат метода на проверку наличия пользователя в системе True при пустых полях
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.User = new Date_Users();
            bool result = obj.CheckOnFailAuthorization();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestUserInSystemFill()//Проверяет будет ли результат метода на проверку наличия пользователя в системе Flase при заполненных полях
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            obj.User = new Date_Users { ID_user = 1 };
            bool result = obj.CheckOnFailAuthorization();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestUserInSystemNotNull()//Проверяет возращает ли метод проверки наличия пользователя в системе не пустое значение
        {
            MainWindowViewModel obj = new MainWindowViewModel();
            bool result = obj.CheckOnFailAuthorization();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestConfirmPasswordCorrect()//Проверяет возвращает ли метод проверки соответствия паролей значние True, при совпадающих паролях
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "123";
            obj.ConfirmPassword = "123";
            bool result = obj.CheckPassword_Confirm();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestConfirmPasswordIncorrect()//Проверяет возварщает ли метод проверки соответсвия паролей значение False, при несовпадающих паролях
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "123";
            obj.ConfirmPassword = "321";
            bool result = obj.CheckPassword_Confirm();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestPasswordMaskIncorrect()//Проверяет возварщает ли метод проверки соответсвия пароля маске значение False, при неккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "123";
            bool result = obj.PasswordCheck();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestPasswordMaskCorrect()//Проверяет возварщает ли метод проверки соответсвия пароля маске значение True, при ккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "A1b2c3";
            bool result = obj.PasswordCheck();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestLoginMaskIncorrect()//Проверяет возварщает ли метод проверки соответсвия логина маске значение False, при неккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "123";
            bool result = obj.LoginCheck();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestLoginMaskCorrect()//Проверяет возварщает ли метод проверки соответсвия логина маске значение True, при ккоректном пароле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "Test";
            bool result = obj.LoginCheck();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEmptyLoginEmpty()//Проверяет возварщает ли метод проверки логина на заполненность True, при пустом поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEmptyLoginNull()//Проверяет возварщает ли метод проверки логина на заполненность True, при значении поля Null
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = null;
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEmptyLoginFill()//Проверяет возварщает ли метод проверки логина на заполненность False, при заполненном поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Login = "Test";
            bool result = obj.CheckLoginOnEmpty();
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestEmptyPasswordEmpty()//Проверяет возварщает ли метод проверки пароля на заполненность True, при пустом поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEpmtyPasswordNull()//Проверяет возварщает ли метод проверки пароля на заполненность True, при значении поля Null
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = null;
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEmptyPasswordNotNull()//Проверяет возварщает ли метод проверки пароля на заполненность False, при заполненном поле
        {
            RegViewModel obj = new RegViewModel();
            obj.Password = "Test";
            bool result = obj.CheckPasswordOnEmpty();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestFioOnEmptyPatronymic()//Проверяет возвращает ли метод на проверку заполненности ФИО результат True, при незаполненном отчестве
        {
            bool result = BasicModel.FioOnEmpty("Ivanov", "Ivan", "");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestFioOnEmptyName()//Проверяет возвращает ли метод на проверку заполненности ФИО результат True, при незаполненном имени
        {
            bool result = BasicModel.FioOnEmpty("Ivanov", "", "Patronymic");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestFioOnEmptySurname()//Проверяет возвращает ли метод на проверку заполненности ФИО результат True, при незаполненной фамилии
        {
            bool result = BasicModel.FioOnEmpty("", "Ivan", "Ivanovich");
            Assert.IsTrue(result);
        }
        public void TestFioOnEmptyPatronymicNull()//Проверяет возвращает ли метод на проверку заполненности ФИО результат True, при нулевом значении отчества
        {
            bool result = BasicModel.FioOnEmpty("Ivanov", "Ivan", null);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestFioOnEmptyNameNull()//Проверяет возвращает ли метод на проверку заполненности ФИО результат True, при нулевом значении имени
        {
            bool result = BasicModel.FioOnEmpty("Ivanov", null, "Patronymic");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestFioOnEmptySurnameNull()//Проверяет возвращает ли метод на проверку заполненности ФИО результат True, при нулевом значении фамилии
        {
            bool result = BasicModel.FioOnEmpty(null, "Ivan", "Ivanovich");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestNumMaskEmpty()//Проверяет возвращает ли метод на проверку маски телефона результат False, при незаполненном поле
        {
            bool result = BasicModel.NumCheck("");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestNumMaskIncorrect()//Проверяет возвращает ли метод на проверку маски телефона результат False, при неправильно заполненном поле
        {
            bool result = BasicModel.NumCheck("7(800)5553535");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestNumMaskCorrect()
        {
            bool result = BasicModel.NumCheck("7(800)555-35-35");//Проверяет возвращает ли метод на проверку маски телефона результат False, при правильно заполненном поле
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestEmailMaskEmpty()//Проверяет возвращает ли метод на проверку маски почты результат False, при незаполненном поле
        {
            bool result = AuthDataModel.CheckEmail("");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestEmailMaskIncorrect()//Проверяет возвращает ли метод на проверку маски почты результат False, при неправильно заполненном поле
        {
            bool result = AuthDataModel.CheckEmail("test@mailru");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestEmailMaskCorrect()//Проверяет возвращает ли метод на проверку маски почты результат False, при правильно заполненном поле
        {
            bool result = AuthDataModel.CheckEmail("test@mail.ru");
            Assert.IsTrue(result);
        }
    }
}
