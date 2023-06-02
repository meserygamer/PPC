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
    public class BasicViewModel : INotifyPropertyChanged
    {
        #region Поля
        private string _name;
        private string _patronymic;
        private string _surname;
        private string _phone;
        private string _confirmName;
        private string _confirmSurname;
        private string _confirmPatronymic;
        private string _confirmPhone;
        private StateSettings _stateOfSettings;
        private RelayCommand _confirmSettings;
        #endregion
        #region Свойства
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                OnProperyChanged("Name");
                StateOfSettings = StateSettings.SettingsChanged;
            }
        }
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                OnProperyChanged("Patronymic");
                StateOfSettings = StateSettings.SettingsChanged;
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnProperyChanged("Surname");
                StateOfSettings = StateSettings.SettingsChanged;
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnProperyChanged("Phone");
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
                            if(BasicModel.FioOnEmpty(Surname, Name, Patronymic))
                            {
                                MessageBox.Show("Строки ФИО должны быть заполнены");
                                ReturnFieldsDataToConfirmState();
                                return;
                            }
                            if(!BasicModel.NumCheck(Phone))
                            {
                                MessageBox.Show("Номер телефона должен вводиться в формате 7(ХХХ)ХХХ-ХХ-ХХ");
                                ReturnFieldsDataToConfirmState();
                                return;
                            }
                            BasicModel.ChangeFIO(Name, Surname, Patronymic, Phone);
                            MessageBox.Show("Данные успешно обновленны");
                            ReturnFieldsDataToConfirmState();
                        }));
            }
        }
        #endregion
        public BasicViewModel()
        {
            _name = ((Date_Users)Application.Current.Resources["UserData"]).Users.Name;
            _surname = ((Date_Users)Application.Current.Resources["UserData"]).Users.Surname;
            _patronymic = ((Date_Users)Application.Current.Resources["UserData"]).Users.Patronymic;
            _phone = ((Date_Users)Application.Current.Resources["UserData"]).Users.Phone;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public void ReturnFieldsDataToConfirmState()
        {
            _confirmName = ((Date_Users)Application.Current.FindResource("UserData")).Users.Name;
            _confirmSurname = ((Date_Users)Application.Current.FindResource("UserData")).Users.Surname;
            _confirmPatronymic = ((Date_Users)Application.Current.FindResource("UserData")).Users.Patronymic;
            _confirmPhone = ((Date_Users)Application.Current.FindResource("UserData")).Users.Phone;
            Name = _confirmName;
            Surname = _confirmSurname;
            Patronymic = _confirmPatronymic;
            Phone = _confirmPhone;
            StateOfSettings = StateSettings.SettingsNotChanged;

            WindowTasksViewModel TVM = new WindowTasksViewModel();
        }
    }
}
