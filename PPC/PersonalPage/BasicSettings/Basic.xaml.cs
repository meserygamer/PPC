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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPC.PersonalPage
{
    /// <summary>
    /// Логика взаимодействия для Basic.xaml
    /// </summary>
    public partial class Basic : UserControl
    {
        public Basic()
        {
            InitializeComponent();
            BasicViewModel obj = new BasicViewModel();
            this.DataContext = obj;
            Binding BindingNameToStaticResource = new Binding() 
            { Source=((Date_Users)Application.Current.Resources["UserData"]).Users,
            Path = new PropertyPath("Name"),
            Mode = BindingMode.TwoWay
            };
            Binding BindingSurnameToStaticResource = new Binding()
            {
                Source = ((Date_Users)Application.Current.Resources["UserData"]).Users,
                Path = new PropertyPath("Surname"),
                Mode = BindingMode.TwoWay
            };
            Binding BindingPatronymicToStaticResource = new Binding()
            {
                Source = ((Date_Users)Application.Current.Resources["UserData"]).Users,
                Path = new PropertyPath("Patronymic"),
                Mode = BindingMode.TwoWay
            };
            Binding BindingPhoneToStaticResource = new Binding()
            {
                Source = ((Date_Users)Application.Current.Resources["UserData"]).Users,
                Path = new PropertyPath("Phone"),
                Mode = BindingMode.TwoWay
            };
            BindingOperations.SetBinding(obj, BasicViewModel.ConfirmNameProperty, BindingNameToStaticResource);
            BindingOperations.SetBinding(obj, BasicViewModel.ConfirmSurnameProperty, BindingSurnameToStaticResource);
            BindingOperations.SetBinding(obj, BasicViewModel.ConfirmPatronymicProperty, BindingPatronymicToStaticResource);
            BindingOperations.SetBinding(obj, BasicViewModel.ConfirmPhoneProperty, BindingPhoneToStaticResource);
        }
    }
}
