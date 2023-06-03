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
        //Хранит имя пользователя
        #region PropertyChanged Name string
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnProperyChanged("Name");
                StateOfSettings = StateSettings.SettingsChanged;
            }
        }
        #endregion
        //Хранит отчество пользователя
        #region PropertyChanged Patronymic string
        private string _patronymic;
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
        #endregion
        //Хранит фамилию пользователя
        #region PropertyChanged Surname string
        private string _surname;
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
        #endregion
        //Хранить телефон пользователя
        #region PropertyChanged Phone string
        private string _phone;
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
        #endregion
        //Хранит подтверждённое имя пользователя
        private string _confirmName;
        //Храни подтверждённую фамилию пользователя
        private string _confirmSurname;
        //Хранит подтверждённое отчество пользователя
        private string _confirmPatronymic;
        //Хранить подтверждённый телефон пользователя
        private string _confirmPhone;
        #region PropertyChaged StateOfSetting StateSettings 
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
        #region Действие при нажатии на кнопку подтверждения изменений
        private RelayCommand _confirmSettings;
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
        #region ProperttyChanged BoilerPlate
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        /// <summary>
        /// Метод возвращающий значения подтверждённых полей
        /// </summary>
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
