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

namespace PPC.PersonalPage
{
    internal class AuthDataViewModel : INotifyPropertyChanged
    {
        #region Поля
        private string _email;
        private string _confirmEmail;
        private string _oldPass;
        private string _newpass;
        private StateSettings _stateOfSettings;
        private RelayCommand _confirmSettings;
        #endregion
        #region Свойства
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnProperyChanged("Email");
                StateOfSettings = StateSettings.SettingsChanged;
            }
        }
        public string Oldpass
        {
            get { return _oldPass; }
            set
            {
                _oldPass = value;
                OnProperyChanged("Oldpass");
                StateOfSettings = StateSettings.SettingsChanged;
            }
        }
        public string Newpass
        {
            get { return _newpass; }
            set
            {
                _newpass = value;
                OnProperyChanged("Newpass");
                StateOfSettings = StateSettings.SettingsChanged;
            }
        }
        public StateSettings StateOfSettings
        {
            get { return _stateOfSettings; }
            set 
            {
                _stateOfSettings = value;
                OnProperyChanged("StateOfSettings");
            }
        }
        public RelayCommand ConfirmSettings
        {
            get
            {
                return _confirmSettings ??
                    (_confirmSettings = new RelayCommand(
                        a =>
                        {
                            if(!AuthDataModel.CheckEmail(Email))
                            {
                                MessageBox.Show("Введенный Email некорректен");
                                ReturnFieldsDataToConfirmState();
                                return;
                            }
                            if(!AuthDataModel.CheckPasswordOnEquals(Oldpass, ((Date_Users)Application.Current.Resources["UserData"]).Password))
                            {
                                MessageBox.Show("Введен неверный пароль");
                                ReturnFieldsDataToConfirmState();
                                return;
                            }
                            if (!AuthDataModel.CheckPassword(Newpass))
                            {
                                MessageBox.Show("Новый пароль не соответсветсвует требованиям");
                                ReturnFieldsDataToConfirmState();
                                return;
                            }
                            AuthDataModel.ChangeAuthData(((Date_Users)Application.Current.Resources["UserData"]).Users.ID_user, Newpass, Email);
                            ReturnFieldsDataToConfirmState();
                            return;
                        }));
            }
        }
        #endregion
        public AuthDataViewModel()
        {
            Email = ((Date_Users)Application.Current.Resources["UserData"]).Users.Email;
            _confirmEmail = Email;
            StateOfSettings = StateSettings.SettingsNotChanged;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public void ReturnFieldsDataToConfirmState()
        {
            _confirmEmail = ((Date_Users)Application.Current.Resources["UserData"]).Users.Email;
            Email = _confirmEmail;
            Oldpass = "";
            Newpass = "";
            StateOfSettings = StateSettings.SettingsNotChanged;
        }
    }
}