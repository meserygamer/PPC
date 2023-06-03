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

            WindowTasksViewModel viewModel = new WindowTasksViewModel();
            DataContext = viewModel;
            #region Привязка имени к значению статического ресурса
            Binding nameToStatic = new Binding();
            nameToStatic.Source = ((Date_Users)Application.Current.Resources["UserData"]).Users;
            nameToStatic.Path = new PropertyPath("Name");
            nameToStatic.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(viewModel, WindowTasksViewModel.NameProperty, nameToStatic);
            #endregion
            #region Привязка фамилии к статическому ресурсу
            Binding surnameToStatic = new Binding();
            surnameToStatic.Source = ((Date_Users)Application.Current.Resources["UserData"]).Users;
            surnameToStatic.Path = new PropertyPath("Surname");
            surnameToStatic.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(viewModel, WindowTasksViewModel.SurnameProperty, surnameToStatic);
            #endregion
        }
        /// <summary>
        /// Происходит при нажатии на кнопку
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Название события</param>
        private void complete_task(object sender, RoutedEventArgs e)
        {
           ((WindowTasksViewModel)(this.DataContext)).updateDB();
        }
        /// <summary>
        /// Пропадения кнопки при переходе на вкладку
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Название события</param>
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
        /// <summary>
        /// Переход на личный кабинет
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Название события</param>
        private void StackPanel_GotFocus(object sender, RoutedEventArgs e)
        {
            PersonalPage.PersonalPage PP = new PersonalPage.PersonalPage();
            PP.Show();
            this.Close();
        }
    }
}
