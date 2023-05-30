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

namespace PPC.PersonalPage
{
    /// <summary>
    /// Логика взаимодействия для AuthData1.xaml
    /// </summary>
    public partial class AuthData : UserControl
    {

        public AuthData()
        {
            InitializeComponent();
            DataContext = new AuthDataViewModel();
            OldPass.PasswordChanged += OldPassword_PasswordChanged;
            NewPass.PasswordChanged += NewPassword_PasswordChanged;
        }
        private void OldPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((AuthDataViewModel)this.DataContext).Oldpass = ((PasswordBox)sender).Password;
            }
        }
        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((AuthDataViewModel)this.DataContext).Newpass = ((PasswordBox)sender).Password;
            }
        }
    }
}
