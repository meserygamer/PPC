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
    public class BasicViewModel : DependencyObject, INotifyPropertyChanged
    {
        #region Поля
        private string _name;
        private string _patronymic;
        private string _surname;
        private string _phone;
        public static readonly DependencyProperty ConfirmNameProperty;
        public static readonly DependencyProperty ConfirmSurnameProperty;
        public static readonly DependencyProperty ConfirmPatronymicProperty;
        public static readonly DependencyProperty ConfirmPhoneProperty;
        /*private string _confirmName;
        private string _confirmSurname;
        private string _confirmPatronymic;
        private string _confirmPhone;*/
        private StateSettings _stateOfSettings;
        private RelayCommand _confirmSettings;
        #endregion
        #region Свойства
        public string ConfirmName
        {
            get
            {
                return (string)GetValue(ConfirmNameProperty);
            }
            set
            {
                SetValue(ConfirmNameProperty, value);
            }
        }
        public string ConfirmSurname
        {
            get
            {
                return (string)GetValue(ConfirmSurnameProperty);
            }
            set
            {
                SetValue(ConfirmSurnameProperty, value);
            }
        }
        public string ConfirmPatronymic
        {
            get
            {
                return (string)GetValue(ConfirmPatronymicProperty);
            }
            set
            {
                SetValue(ConfirmPatronymicProperty, value);
            }
        }
        public string ConfirmPhone
        {
            get
            {
                return (string)GetValue(ConfirmPhoneProperty);
            }
            set
            {
                SetValue(ConfirmPhoneProperty, value);
            }
        }
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
                                MessageBox.Show("Введите свои фамилию, имя и отчество");
                                return;
                            }
                            if(!BasicModel.NumCheck(Phone))
                            {
                                MessageBox.Show("Номер телефона должен вводиться в формате 7(ХХХ)ХХХ-ХХ-ХХ");
                                return;
                            }
                            MessageBox.Show("Данные успешно");
                        }));
            }
        }
        #endregion
        static BasicViewModel()
        {
            ConfirmNameProperty = DependencyProperty.Register("ConfirmName", typeof(string), typeof(BasicViewModel));
            ConfirmNameProperty = DependencyProperty.Register("ConfirmSurname", typeof(string), typeof(BasicViewModel));
            ConfirmNameProperty = DependencyProperty.Register("ConfirmPatronymic", typeof(string), typeof(BasicViewModel));
            ConfirmNameProperty = DependencyProperty.Register("ConfirmPhone", typeof(string), typeof(BasicViewModel));
        }
        public BasicViewModel()
        {
            ReturnFieldsDataToConfirmState();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public void ReturnFieldsDataToConfirmState()
        {
            Name = ConfirmName;
            Surname = ConfirmSurname;
            Patronymic = ConfirmPatronymic;
            Phone = ConfirmPhone;
            StateOfSettings = StateSettings.SettingsNotChanged;
        }
    }
}
