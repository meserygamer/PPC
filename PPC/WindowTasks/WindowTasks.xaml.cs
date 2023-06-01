using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PPC
{
    /// <summary>
    /// Логика взаимодействия для WindowTasks.xaml
    /// </summary>
    public partial class WindowTasks : Window
    {   
        public WindowTasks()
        {
            InitializeComponent();
            //Данные для вывода актуальных задач
            WindowTasksViewModel viewModel = new WindowTasksViewModel();
            DataContext = viewModel;
            //Реализация динамического изменения имени для отображения 
            Binding nameToStatic = new Binding();
            Binding surnameToStatic = new Binding();
            nameToStatic.Source = ((Date_Users)Application.Current.Resources["UserData"]).Users;
            surnameToStatic.Source = ((Date_Users)Application.Current.Resources["UserData"]).Users;
            nameToStatic.Path = new PropertyPath("Name");
            surnameToStatic.Path = new PropertyPath("Surname");
            nameToStatic.Mode = BindingMode.TwoWay;
            surnameToStatic.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(viewModel, WindowTasksViewModel.NameProperty, nameToStatic);
            BindingOperations.SetBinding(viewModel, WindowTasksViewModel.SurnameProperty, surnameToStatic);            

        }
        //Функция вызова изменений статуса задач "Активная" -> "Выполнено"
        private void Complete_task(object sender, RoutedEventArgs e)
        {
           ((WindowTasksViewModel)(this.DataContext)).updateDB();
        }
        //Функция изменения видимость кнопки для разных задач
        private void ClicToTab(object sender, SelectionChangedEventArgs e)
        {
            if (tabActive.IsSelected)
            {
                but_complete.Visibility = Visibility.Visible;
            }
            if (tabComplete.IsSelected)
            {
                but_complete.Visibility = Visibility.Hidden ;
            }   
        }
    }
}
