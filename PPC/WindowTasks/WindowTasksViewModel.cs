using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.SqlClient;

namespace PPC
{
    public class WindowTasksViewModel :DependencyObject, INotifyPropertyChanged
    {
        //Выбранная задача
        #region PropertyChanged SelectedTask WindowsTaskModel
        private WindowTasksModel _selectedTask;
        public WindowTasksModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }
        #endregion
        //Список активных задач
        #region PropertyChanged ActiveTask ObservableCollection<WindowTasksModel> 
        public ObservableCollection<WindowTasksModel> _active_task;
        public ObservableCollection<WindowTasksModel> Active_task
        {
            get { return _active_task; }
            set
            {
                _active_task = value;
                OnPropertyChanged("Active_task");
            }
        }
        #endregion
        //Список завершённых задач
        #region PropertyChanged CompleteTask ObservableCollection<WindowTasksModel>
        public ObservableCollection<WindowTasksModel> _complete_task;
        public ObservableCollection<WindowTasksModel> Complete_task
        {
            get { return _complete_task; }
            set
            {
                _complete_task = value;
                OnPropertyChanged("Complete_task");
            }
        }
        #endregion
        //Фамилия пользователя
        #region DependencyProperty Surname string
        public static readonly DependencyProperty SurnameProperty;
        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }
        #endregion
        //Имя пользователя
        #region DependencyProperty Name string
        public static readonly DependencyProperty NameProperty;
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        #endregion
        #region DependencyProperty BoilerPlate
        static WindowTasksViewModel()
        {
            SurnameProperty = DependencyProperty.Register("Surname", typeof(string), typeof(WindowTasksViewModel));
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(WindowTasksViewModel));
        }
        #endregion
        public WindowTasksViewModel()
        {
            updateSourse();
        }
        /// <summary>
        /// Метод обновления источника данных для списка задач
        /// </summary>
        private void updateSourse()
        {
            using (TheBestV2Entities DB = new TheBestV2Entities())
            {
                DB.Task.Where(a => a.ID_user == ((Date_Users)Application.Current.Resources["UserData"]).ID_user);

                Active_task = new ObservableCollection<WindowTasksModel>(ConvertTasksToWindowModel(
                    DB.Task.ToList().Where(a => a.ID_user == ((Date_Users)Application.Current.Resources["UserData"]).ID_user).Where(a => a.Date_task.ID_status == 1).ToList()));
                Complete_task = new ObservableCollection<WindowTasksModel>(ConvertTasksToWindowModel(
                    DB.Task.ToList().Where(a => a.ID_user == ((Date_Users)Application.Current.Resources["UserData"]).ID_user).Where(a => a.Date_task.ID_status == 2).ToList()));
            }
        }
        /// <summary>
        /// Конвертация из List<task> в List<WindowTasksModel>
        /// </summary>
        /// <param name="b">Список задач из БД</param>
        /// <returns>Возращает список задач в формате List<WindowTaskModel></returns>
        private List<WindowTasksModel> ConvertTasksToWindowModel(List<Task> b)
        {
            List<WindowTasksModel> a = new List<WindowTasksModel>();           
            foreach(Task task in b)
            {
                a.Add(new WindowTasksModel() {
                    Id_task = task.Date_task.ID_task,
                    Name_task = task.Date_task.Name_task,
                    Date_finish_job = task.Date_task.Date_finish_job,
                    Date_start_job = task.Date_task.Date_start_job,
                    Description_task = task.Date_task.Description_task });
            }
            return a;
        }
        /// <summary>
        /// Метод переноса задач из активных в завершённые
        /// </summary>
        public void updateDB()
        {
            if (_selectedTask != null)
            {
                using (TheBestV2Entities DB = new TheBestV2Entities())
                {
                    Date_task DT = DB.Date_task.Find(_selectedTask.Id_task);
                    DT.ID_status = 2;
                    DB.SaveChanges();
                }
                updateSourse();
            }
            else
            {
                MessageBox.Show("Нет задач на выполнение");
            }
        }
        #region PropertyChanged BoilerPlate
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
