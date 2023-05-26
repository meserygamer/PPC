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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Auth;

namespace PPC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Login.LostFocus += Login_TextChanged;
            Password.LostFocus += Password_PasswordChanged;
        }
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Authtorization.GetAuthorization().password = ((PasswordBox)sender).Password;
        }
        private void Login_TextChanged(object sender, System.EventArgs e)
        {
            Authtorization.GetAuthorization().login = ((TextBox)sender).Text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Login.Text == "")
            {
                MessageBox.Show("Введите значение в поле логина");
                return;
            }
            if(Password.Password == "")
            {
                MessageBox.Show("Введите значение в поле пароля");
                return;
            }
            Date_Users User;
            using(UserContext context = new UserContext())
            {
                User = Authtorization.GetAuthorization().Authorization(context.Date_Users.ToList());
            }
            if(User.Login is null)
            {
                MessageBox.Show("Вход в систему неудачен");
                return;
            }
            else
            {
                MessageBox.Show("Вход выполнен успешно");
                ///////Код для перехода на следующее окно
            }
        }
    }
}
