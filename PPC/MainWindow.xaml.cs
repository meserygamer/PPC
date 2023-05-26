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
            Login.TextChanged += Login_TextChanged;
            Password.PasswordChanged += Password_PasswordChanged; ;
        }
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Authtorization.GetAuthorization().password = Password.Password;
        }
        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            Authtorization.GetAuthorization().login = Login.Text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authtorization.GetAuthorization().Authorization();
        }
    }
}
