using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace PPC
{
    public class WindowTasksViewModel : INotifyPropertyChanged
    {
        private WindowTasksModel selectedTask;
        public ObservableCollection<WindowTasksModel> Active_task { get; set; }
        public ObservableCollection<WindowTasksModel> Complete_task { get; set; }
        public WindowTasksModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
            }
        }      
        public WindowTasksViewModel()
        {
            using (TheBestV2Entities DB = new TheBestV2Entities())
            {
                Active_task = new ObservableCollection<WindowTasksModel>(ConvertTasksToWindowModel(DB.Active_tasks.ToList()));
                Complete_task = new ObservableCollection<WindowTasksModel>(ConvertTasksToWindowModel(DB.Complete_tasks.ToList()));
            }
        }
        private List<WindowTasksModel> ConvertTasksToWindowModel(List<Active_tasks> b)
        {
            List<WindowTasksModel> a = new List<WindowTasksModel>();           
            foreach(Active_tasks task in b)
            {
                a.Add(new WindowTasksModel() {
                    Name_task = task.Name_tasks, 
                    Date_finish_job=task.Date_finish_job, 
                    Date_start_job=task.Date_start_job, 
                    Description_task=task.Description_task});
            }
            return a;
        }
        private List<WindowTasksModel> ConvertTasksToWindowModel(List<Complete_tasks> b)
        {
            List<WindowTasksModel> a = new List<WindowTasksModel>();
            foreach (Complete_tasks task in b)
            {
                a.Add(new WindowTasksModel()
                {
                    Name_task = task.Name_tasks,
                    Date_finish_job = task.Date_finish_job,
                    Date_start_job = task.Date_start_job,
                    Description_task = task.Description_task
                });
            }
            return a;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
