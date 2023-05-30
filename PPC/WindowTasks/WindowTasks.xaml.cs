using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

            DataContext = new WindowTasksViewModel();
        }
        private void complete_task(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Задача была перенесена в категорию \"Выполнено\"");
        }
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
