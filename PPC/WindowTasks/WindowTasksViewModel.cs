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

namespace PPC
{
    public class WindowTasksViewModel :DependencyObject, INotifyPropertyChanged
    {
        private WindowTasksModel selectedTask;
        public ObservableCollection<WindowTasksModel> Active_task { get; set; }
        public ObservableCollection<WindowTasksModel> Complete_task { get; set; }
        public static readonly DependencyProperty SurnameProperty;
        public static readonly DependencyProperty NameProperty;
        public WindowTasksModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }
        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set { SetValue(SurnameProperty, value); }
        }
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        static WindowTasksViewModel()
        {
            SurnameProperty = DependencyProperty.Register("Surname", typeof(string), typeof(WindowTasksViewModel));
            NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(WindowTasksViewModel));
        }
        public WindowTasksViewModel()
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
        private List<WindowTasksModel> ConvertTasksToWindowModel(List<Task> b)
        {
            List<WindowTasksModel> a = new List<WindowTasksModel>();           
            foreach(Task task in b)
            {
                a.Add(new WindowTasksModel() {
                    //FIO = task.Users.Surname +" "+ task.Users.Name,
                    Name_task = task.Date_task.Name_task,
                    Date_finish_job = task.Date_task.Date_finish_job,
                    Date_start_job = task.Date_task.Date_start_job,
                    Description_task = task.Date_task.Description_task });
            }
            return a;
        }
        public void updateDB(object sender, RoutedEventArgs e)
        {
            using (TheBestV2Entities db = new TheBestV2Entities())
            {
                Date_task task= new Date_task
                {
                    ID_status=2
                };
               // db.Date_task. .Add(AuthUser);
                db.SaveChanges();
            }
        }
        //private List<WindowTasksModel> ConvertTasksToWindowModel(List<Complete_tasks> b)
        //{
        //    List<WindowTasksModel> a = new List<WindowTasksModel>();
        //    foreach (Complete_tasks task in b)
        //    {
        //        a.Add(new WindowTasksModel()
        //        {
        //            Name_task = task.Name_tasks,
        //            Date_finish_job = task.Date_finish_job,
        //            Date_start_job = task.Date_start_job,
        //            Description_task = task.Description_task
        //        });
        //    }
        //    return a;
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
