﻿using System;
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
        }
    }
}
