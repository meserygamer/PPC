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
        //Номер выбранной задачи
        #region PropertyChanged ID_Task int
        private int id_task;
        public int Id_task
        {
            get { return id_task; }
            set
            {
                id_task = value;
                OnPropertyChanged("Id_task");
            }
        }
        #endregion
        //Название выбранной задачи
        #region PropertyChanged NameTask string
        private string name_task;
        public string Name_task
        {
            get { return name_task; }
            set
            {
                name_task = value;
                OnPropertyChanged("Name_task");
            }
        }
        #endregion
        //Описание выбранной задачи
        #region PropertyChanged DesriptionTask string
        private string description_task;
        public string Description_task
        {
            get { return description_task; }
            set
            {
                description_task = value;
                OnPropertyChanged("Description_task");
            }
        }
        #endregion
        //Дата начала задачи
        #region ProprtyChanged DateStartJob Nullable<System.DateTime>
        private Nullable<System.DateTime> date_start_job;
        public Nullable<System.DateTime> Date_start_job
        {
            get { return date_start_job; }
            set
            {
                date_start_job = value;
                OnPropertyChanged("Date_start_job");
            }
        }
        #endregion
        //Дата окончания задачи
        #region  ProprtyChanged DateFinishJob Nullable<System.DateTime>
        private Nullable<System.DateTime> date_finish_job;
        public Nullable<System.DateTime> Date_finish_job
        {
            get { return date_finish_job; }
            set
            {
                date_finish_job = value;
                OnPropertyChanged("Date_finish_job");
            }
        }
        #endregion
        #region BoilerPlate PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
