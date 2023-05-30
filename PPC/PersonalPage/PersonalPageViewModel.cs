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
    public class PersonalPageViewModel : INotifyPropertyChanged
    {
        #region Поля
        private TabOfSettings _currentTab;
        private RelayCommand _authButton;
        private RelayCommand _basicButton;
        private AuthData _authData;
        private Basic _basicData;
        private UserControl _currentSettings;
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
        public RelayCommand AuthButton
        {
            get {
                return _authButton ??
                    (_authButton = new RelayCommand(a =>
                    {
                        CurrentTab = TabOfSettings.AuthSettings;
                        CurrentSettings = _authData;
                    })); 
            }
        }
        public RelayCommand BasicButton
        {
            get
            {
                return _basicButton ??
                    (_basicButton = new RelayCommand(a =>
                    {
                        CurrentTab = TabOfSettings.BasicSettings;
                        CurrentSettings = _basicData;
                    }));
            }
        }
        public UserControl CurrentSettings
        {
            get { return _currentSettings; }
            set
            {
                _currentSettings = value;
                OnProperyChanged("CurrentSettings");
            }
        }
        #endregion
        public PersonalPageViewModel()
        {
            CurrentTab = TabOfSettings.BasicSettings;
            _basicData = new Basic();
            _authData = new AuthData();
            CurrentSettings = _basicData;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute(parameter);
        public void Execute(object parameter) => this.execute(parameter);
    }
}
