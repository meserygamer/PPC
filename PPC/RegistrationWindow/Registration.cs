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

namespace PPC
{
    public class Registration : DependencyObject
    {
        public static readonly DependencyProperty LoginProperty;
        public static readonly DependencyProperty PasswordProperty;
        public static readonly DependencyProperty ConfirmPasswordProperty;

        static Registration()
        {
            LoginProperty = DependencyProperty.Register("Login", typeof(string), typeof(Registration));
            PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(Registration));
            ConfirmPasswordProperty = DependencyProperty.Register("ConfirmPassword", typeof(string), typeof(Registration));
        }
        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public string ConfirmPassword
        {
            get { return (string)GetValue(ConfirmPasswordProperty); }
            set { SetValue(ConfirmPasswordProperty, value); }
        }
    }
}
