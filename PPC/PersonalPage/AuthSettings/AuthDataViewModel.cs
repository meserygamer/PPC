using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    internal class AuthDataViewModel : INotifyPropertyChanged
    {
        #region Поля
        private string _email;
        private string _oldpass;
        private string _newpass;
        #endregion
        #region Свойства
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnProperyChanged("Email");
            }
        }
        public string Oldpass
        {
            get { return _oldpass; }
            set
            {
                _oldpass = value;
                OnProperyChanged("Oldpass");
            }
        }
        public string Newpass
        {
            get { return _newpass; }
            set
            {
                _newpass = value;
                OnProperyChanged("Newpass");
            }
        }
        #endregion
        public AuthDataViewModel()
        {
            Email = ((Date_Users)Application.Current.Resources["UserData"]).Users.Email;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}