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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        Authorization AuthorizationModel { get; set; }
        private string login;
        public string password {private get; set; }
        private AuthtorizationCommand authtorizationCommand;
        private Date_Users User;
        public AuthtorizationCommand Auth
        {
            get
            {
                return authtorizationCommand ??
                    (authtorizationCommand = new AuthtorizationCommand(
                        a => { if (CheckLoginOnEmpty()) return;
                        if(CheckPasswordOnEmpty()) return;
                        User = Authorization.AuthorizationInSystem(login, password);
                        if(CheckOnFailAuthorization()) return;
                        MessageBox.Show("Авторизация прошла успешно");}));
            }
        }
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public MainWindowViewModel()
        {
            AuthorizationModel = new Authorization();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        private bool CheckLoginOnEmpty()
        {
            if(login == "")
            {
                MessageBox.Show("Введите значение в поле логина");
                return true;
            }
            return false;
        }
        private bool CheckPasswordOnEmpty()
        {
            if(password == "")
            {
                MessageBox.Show("Введите значение в поле пароля");
                return true;
            }
            return false;
        }
        private bool CheckOnFailAuthorization()
        {
            if(User is null || User.ID_user is null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return true;
            }
            return false;
        }
    }
    public class AuthtorizationCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public AuthtorizationCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter) => this.canExecute == null || this.canExecute(parameter);
        public void Execute(object parameter) => this.execute(parameter);
    }
}