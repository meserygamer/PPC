using Microsoft.Xaml.Behaviors;
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
            //OldPass.PasswordChanged += OldPassword_PasswordChanged;
            //NewPass.PasswordChanged += NewPassword_PasswordChanged;
        }
        //private void OldPassword_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    if (this.DataContext != null)
        //    {
        //        ((AuthDataViewModel)this.DataContext).Oldpass = ((PasswordBox)sender).Password;
        //    }
        //}
        //private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        //{
        //    if (this.DataContext != null)
        //    {
        //        ((AuthDataViewModel)this.DataContext).Newpass = ((PasswordBox)sender).Password;
        //    }
        //}
    }
    public class PasswordBehavior : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordBehavior), new PropertyMetadata(default(string)));

        private bool _skipUpdate;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += PasswordBox_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PasswordChanged -= PasswordBox_PasswordChanged;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == PasswordProperty)
            {
                if (!_skipUpdate)
                {
                    _skipUpdate = true;
                    AssociatedObject.Password = e.NewValue as string;
                    _skipUpdate = false;
                }
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _skipUpdate = true;
            Password = AssociatedObject.Password;
            _skipUpdate = false;
        }
    }
}
