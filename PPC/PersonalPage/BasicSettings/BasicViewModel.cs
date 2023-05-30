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
        #endregion
        #region Свойства
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                OnProperyChanged("Name");
            }
        }
        public string Patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                OnProperyChanged("Patronymic");
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnProperyChanged("Surname");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnProperyChanged("Phone");
            }
        }
        #endregion
        public BasicViewModel()
        {
            Name = ((Date_Users)Application.Current.Resources["UserData"]).Users.Name;
            Surname = ((Date_Users)Application.Current.Resources["UserData"]).Users.Surname;
            Patronymic = ((Date_Users)Application.Current.Resources["UserData"]).Users.Patronymic;
            Phone = ((Date_Users)Application.Current.Resources["UserData"]).Users.Phone;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
