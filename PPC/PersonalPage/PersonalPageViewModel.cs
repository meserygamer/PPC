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
    public class PersonalPageViewModel : INotifyPropertyChanged
    {
        #region Поля
        private TabOfSettings _currentTab;
        #endregion
        #region Свойства
        public TabOfSettings CurrentTab
        {
            get { return _currentTab; }
            set {
                _currentTab = value;
                OnProperyChanged("CurrentTab");
            }
        }
        #endregion
        public PersonalPageViewModel()
        {
            CurrentTab = TabOfSettings.BasicSettings;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
