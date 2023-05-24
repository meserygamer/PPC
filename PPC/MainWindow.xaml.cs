﻿using System;
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
    public class Authtorization
    {
        private static Authtorization instance;
        public string login;
        public string password;
        private Authtorization()
        {
            login = "";
            password = "";
        }
        public static Authtorization GetAuthorization()
        {
            if (instance == null)
            {
                instance = new Authtorization();
                return instance;
            }
            else
            {
                return instance;
            }
        }
        public void Authorization()
        {
            if (login.Length == 0)
            {
                MessageBox.Show("Введите значение в поле логина");
                return;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("Введите значение в поле пароля");
                return;
            }
            using(UserContext db = new UserContext())
            {
                if (db.Date_Users.Where(a => a.Password == password && a.Login == login).Count() == 0)
                {
                    MessageBox.Show("Вход в систему неудачен");
                    return;
                }
                else App.AuthorizationData = (db.Date_Users.Where(a => a.Password == password && a.Login == login).First());
                MessageBox.Show("Вход выполнен успешно");
            }
        }
    }
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
