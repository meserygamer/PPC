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
        /// <summary>
        /// Здесь хранится пароль
        /// </summary>
        public string password {private get; set; }
        /// <summary>
        /// Данные пользователя полученные в результате поиска по БД
        /// </summary>
        public Date_Users User;
        #region Команда клика по кнопке авторизации
        private AuthtorizationCommand authtorizationCommand;
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
                        TransferToTasks((Window)a, User);}));
            }
        }
        #endregion
        #region PropertyChanged Login String
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        #endregion
        public MainWindowViewModel()
        {
            AuthorizationModel = new Authorization();
        }
        #region PropertyChanged BoilerPlate
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Проверка логина на пустоту
        /// </summary>
        /// <returns>Возращает результат проверки</returns>
        public bool CheckLoginOnEmpty()
        {
            if(login == "" || login == null)
            {
                MessageBox.Show("Введите значение в поле логина");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверка пароля на пустоту
        /// </summary>
        /// <returns>Возращает результат проверки</returns>
        public bool CheckPasswordOnEmpty()
        {
            if(password == "" || password == null)
            {
                MessageBox.Show("Введите значение в поле пароля");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверка на неправильную авторизацию
        /// </summary>
        /// <returns>Возращает результат проверки</returns>
        public bool CheckOnFailAuthorization()
        {
            if(User is null || User.ID_user is null)
            {
                MessageBox.Show("Неправильный логин или пароль");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Переход к окну задач
        /// </summary>
        /// <param name="CurrentWin">Текущее окно</param>
        /// <param name="UserData">Данные пользователя из БД</param>
        public void TransferToTasks(Window CurrentWin, Date_Users UserData)
        {
            Application.Current.Resources["UserData"] = UserData;
            WindowTasks WT = new WindowTasks();
            WT.Show();
            CurrentWin.Close();
        }
        #endregion
    }
    #region BoilerPlate Command
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
    #endregion
}