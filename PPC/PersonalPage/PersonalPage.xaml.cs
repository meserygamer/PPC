using System;
using System.Collections.Generic;
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

namespace PPC.PersonalPage
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class PersonalPage : Window
    {
        public PersonalPage()
        {
            InitializeComponent();
            this.DataContext = new PersonalPageViewModel();
        }
        /// <summary>
        /// Открывает окно задач и закрывает текущее окно
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Заголовок события</param>
        private void ClickToTask(object sender, RoutedEventArgs e)
        {
            WindowTasks PP = new WindowTasks();
            PP.Show();
            this.Close();
        }
    }

  
}
