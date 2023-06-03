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
using System.Text.RegularExpressions;


namespace PPC
{
    public class RegViewModel : INotifyPropertyChanged
    {
        //Хранит в себе логин
        #region PropertyChanged Login string
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnProperyChanged("Login");
            }
        }
        #endregion
        /// <summary>
        /// Хранит в себе пароль
        /// </summary>
        public string Password { private get; set; }
        /// <summary>
        /// Хранит в себе подтверждённый пароль
        /// </summary>
        public string ConfirmPassword { private get; set; }
        #region Хранит в себе действия при нажатии на кнопку регистрации
        private RelayCommand registrationCommand;
        public RelayCommand RegistrationCommand 
        {
            get
            {
                return registrationCommand ?? (registrationCommand
                    = new RelayCommand(a =>
                    {
                        if(RegModel.CheckLoginInSystem(login)==true)
                        {
                            MessageBox.Show("Пользователь с таким логином уже есть в системе");
                            return;
                        }
                        if(CheckPassword_Confirm()==false)
                        {
                            return;
                        }
                        if(PasswordCheck()==false)
                        {
                            return;
                        }
                        if(LoginCheck()==false)
                        {
                            return;
                        }
                        TransferToTasks((Window)a, RegModel.AddUser(login, Password));
                    }));
            }
        }
        #endregion
        public RegViewModel(){}
        #region PropertyChanged BoilerPlate
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        #region Методы проверки полей
        /// <summary>
        /// Проверка паролей на совпадение
        /// </summary>
        /// <returns>Возвращает результат проверки</returns>
        public bool CheckPassword_Confirm()
        {
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Пароли в полях не совпадают");
                return false;
            }
            else return true;
        }
        /// <summary>
        /// Проверка пароля на соответствие маске
        /// </summary>
        /// <returns>Возвращает результат проверки</returns>
        public bool PasswordCheck()
        {
            if (!Regex.IsMatch(Password, "^(?=.*[A-Z])(?=.*[0-9])[A-z0-9]{6,}$"))
            {
                MessageBox.Show("Пароль не надо такой");
                return false;
            }
            else return true;
        }
        /// <summary>
        /// Проверка логина на соответствие маске
        /// </summary>
        /// <returns>Возвращает результат проверки</returns>
        public bool LoginCheck() 
        {
            if(!Regex.IsMatch(Login, "^[A-z0-9]{4,}$"))
            {
                MessageBox.Show("Логин не надо такой");
                return false;
            }
            else return true ;
        }
        /// <summary>
        /// Проверка логина на заполненность
        /// </summary>
        /// <returns>Возвращает результат проверки</returns>
        public bool CheckLoginOnEmpty()
        {
            if (login == "" || login == null)
            {
                MessageBox.Show("Введите значение в поле логина");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Проверка пароля на заполненность
        /// </summary>
        /// <returns>Возвращает результат проверки</returns>
        public bool CheckPasswordOnEmpty()
        {
            if (Password == "" || Password == null)
            {
                MessageBox.Show("Введите значение в поле пароля");
                return true;
            }
            return false;
        }
        #endregion
        /// <summary>
        /// Переход к полю задач
        /// </summary>
        /// <param name="CurrentWin">Текущее окно</param>
        /// <param name="UserData">Данные пользователя</param>
        public void TransferToTasks(Window CurrentWin, Date_Users UserData)
        {
            Application.Current.Resources["UserData"] = UserData;
            WindowTasks WT = new WindowTasks();
            WT.Show();
            CurrentWin.Close();
        }
    }
    #region RelayCommand BoilerPlate
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
    #endregion
}
