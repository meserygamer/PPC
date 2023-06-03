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
    internal class AuthDataViewModel : DependencyObject, INotifyPropertyChanged
    {
        //Поле хранит введённый маил
        #region PropertyChanged Email string
        private string _email;
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
        #endregion
        //Поле хранит введённый старый пароль
        #region PropertyChanged OldPassword string
        private string _oldPass;
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
        #endregion
        //Поле хранит введённый новый пароль
        #region PropertyChanged NewPassword string
        private string _newpass;
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
        #endregion
        //Хранит в себе ссостояние изменения настроек
        #region PropertyChanged StateOfSettings StateSettings
        private StateSettings _stateOfSettings;
        public StateSettings StateOfSettings
        {
            get { return _stateOfSettings; }
            set
            {
                _stateOfSettings = value;
                OnProperyChanged("StateOfSettings");
            }
        }
        #endregion
        #region Действие при нажатии на кнопку изменения данных
        private RelayCommand _confirmSettings;
        public RelayCommand ConfirmSettings
        {
            get
            {
                return _confirmSettings ??
                    (_confirmSettings = new RelayCommand(
                        a =>
                        {
                            if (!AuthDataModel.CheckEmail(Email))
                            {
                                MessageBox.Show("Введенный Email некорректен");
                                ReturnFieldsDataToConfirmState();
                                return;
                            }
                            AuthDataModel.ChangeAuthData(Email, ((Date_Users)Application.Current.Resources["UserData"]).Users.ID_user);
                            if (Oldpass == "" || Oldpass == null)
                            {
                                ReturnFieldsDataToConfirmState();
                                return;
                            }
                            if (!AuthDataModel.CheckPasswordOnEquals(Oldpass, ((Date_Users)Application.Current.Resources["UserData"]).Password))
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
                            MessageBox.Show("Успех");
                            AuthDataModel.ChangeAuthData(((Date_Users)Application.Current.Resources["UserData"]).Users.ID_user, Newpass, Email);
                            ReturnFieldsDataToConfirmState();
                            return;
                        }));
            }
        }
        #endregion
        //Хранит в себе подтверждённый маил из статического ресурса
        #region DependencyProperty ConfirmEmail string
        public static readonly DependencyProperty ConfirmEmailProperty;
        public string ConfirmEmail
        { 
            get
            {
                return (string)GetValue(ConfirmEmailProperty);
            }
            set
            {
                SetValue(ConfirmEmailProperty, value);
            }
        }
        static AuthDataViewModel()
        {
            ConfirmEmailProperty = DependencyProperty.Register("ConfirmEmail", typeof(string), typeof(AuthDataViewModel));
        }
        #endregion
        public AuthDataViewModel()
        {
            Email = ((Date_Users)Application.Current.Resources["UserData"]).Users.Email;
            StateOfSettings = StateSettings.SettingsNotChanged;
        }
        #region BoilerPlate PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        /// <summary>
        /// Возращает поля к подтверждённым значениям
        /// </summary>
        public void ReturnFieldsDataToConfirmState()
        {
            ConfirmEmail = ((Date_Users)Application.Current.Resources["UserData"]).Users.Email;
            Email = ConfirmEmail;
            Oldpass = "";
            Newpass = "";
            StateOfSettings = StateSettings.SettingsNotChanged;
        }
    }
}