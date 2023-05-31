using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PPC
{
    public class WindowTasksModel : INotifyPropertyChanged
    {
        private string name_task;
        private string description_task;
        private Nullable<System.DateTime> date_start_job;
        private Nullable<System.DateTime> date_finish_job;
        //private string fio;

        public string Name_task
        {
            get { return name_task; }
            set
            {
                name_task = value;
                OnPropertyChanged("Name_task");
            }
        }
        /*
        public string FIO
        {
            get { return fio; }
            set
            {
                fio = value;
                OnPropertyChanged("FIO");
            }
        }
        */
        public string Description_task
        {
            get { return description_task; }
            set
            {
                description_task = value;
                OnPropertyChanged("Description_task");
            }
        }
        public Nullable<System.DateTime> Date_start_job
        {
            get { return date_start_job; }
            set
            {
                date_start_job = value;
                OnPropertyChanged("Date_start_job");
            }
        }
        public Nullable<System.DateTime> Date_finish_job
        {
            get { return date_finish_job; }
            set
            {
                date_finish_job = value;
                OnPropertyChanged("Date_finish_job");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
