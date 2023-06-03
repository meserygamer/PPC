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
            this.DataContext = new RegViewModel();
            PasswordReg.PasswordChanged += PasswordReg_PasswordChanged; ;
            ConfirmPassword.PasswordChanged += ConfirmPassword_PasswordChanged; ;
        }
        /// <summary>
        /// Привязка поля пароля к ViewModel
        /// </summary>
        /// <param name="sender">Отпрвитель</param>
        /// <param name="e">Название события</param>
        private void PasswordReg_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(this.DataContext != null)
            {
                ((RegViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
        /// <summary>
        /// Привящка поля подтверждённого пароля к ViewModel
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Название события</param>
        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((RegViewModel)this.DataContext).ConfirmPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}
