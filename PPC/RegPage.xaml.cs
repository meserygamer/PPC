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
        }
    }
}
