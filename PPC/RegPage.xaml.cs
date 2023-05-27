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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace PPC
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class RegPage : Window
    {
        public RegPage()
        {
            InitializeComponent();
            PasswordReg.PasswordChanged += PasswordReg_PasswordChanged;
            ConfirmPassword.PasswordChanged += PasswordReg_PasswordChanged;
        }
        private void PasswordReg_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Tag = ((PasswordBox)sender).Password;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{((Registration)this.Resources["Reg"]).Login}" +
                $"\n{((Registration)this.Resources["Reg"]).Password}" +
                $"\n{((Registration)this.Resources["Reg"]).ConfirmPassword}");
            string UserLogin = ((Registration)this.Resources["Reg"]).Login;
            if (!PasswordCheck(((Registration)this.Resources["Reg"]).Password))
            {
                MessageBox.Show("В пароле должны быть как минимум один заглавный символ и цифра, а также не менее 6 символов");
                return;
            }
            if(!LoginCheck(UserLogin))
            {
                MessageBox.Show("В логине должно быть минимум 4 символа");
                return;
            }
            using(TheBestV2Entities DB = new TheBestV2Entities())
            {
                if(DB.Date_Users.Where(a => a.Login == UserLogin).Count() > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже присутствует в системе");
                    return;
                }
            }
            if(!Password_ConfirmPassword(((Registration)this.Resources["Reg"]).Password,
                ((Registration)this.Resources["Reg"]).ConfirmPassword))
            {
                MessageBox.Show("Пароли не пароли совпадают не совпадают");
                return;
            }
        }
        private bool PasswordCheck(string Password) => Regex.IsMatch(Password, "^(?=.*[A-Z])(?=.*[0-9])[A-z0-9]{6,}$");
        private bool LoginCheck(string Login) => Regex.IsMatch(Login, "^[A-z0-9]{4,}$");
        private bool Password_ConfirmPassword(string Password, string ConfPassword) => Password == ConfPassword;
        //private void InsertData(string Login, string Password)
        //{
        //    using(UserContext db = new UserContext())
        //    {
        //        db.Date_Users.Add(new Date_Users() {Login = Login, Password = Password});
        //    }
        //}
    }
}
