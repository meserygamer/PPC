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
    public class RegViewModel : INotifyPropertyChanged
    {
        private string login;
        public string Password { private get; set; }
        public string ConfirmPassword { private get; set; }
        private RelayCommand registrationCommand;
        public RelayCommand RegistrationCommand 
        {
            get
            {
                return registrationCommand ?? (registrationCommand
                    = new RelayCommand(a =>
                    {

                    }
                    ));
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnProperyChanged("Login");
            }
        }
        public RegViewModel(){}
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
