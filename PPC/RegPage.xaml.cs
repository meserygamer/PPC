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
            PasswordCheck();
            LoginCheck();
            Password_ConfirmPassword();
        }
        private void PasswordCheck()
        {
            Regex pass = new Regex("^(?=.*[A-Z])(?=.*[0-9])[A-z0-9]{6,}$");
            bool check = pass.IsMatch(((Registration)this.Resources["Reg"]).Password);
            if (check != true)
            {
                MessageBox.Show("В пароле должны быть как минимум один заглавный символ и цифра, а также не менее 6 символов");
            }
        }
        private void LoginCheck()
        {
            Regex pass = new Regex("^[A-z0-9]{4,}$");
            bool check = pass.IsMatch(((Registration)this.Resources["Reg"]).Login);
            if (check != true)
            {
                MessageBox.Show("В логине должно быть минимум 4 символа");
            }
        }
        private void Password_ConfirmPassword()
        {
            if (((Registration)this.Resources["Reg"]).Password != ((Registration)this.Resources["Reg"]).ConfirmPassword)
            {
                MessageBox.Show("Пароли не пароли совпадают не совпадают");
            }
        }

    }
}
