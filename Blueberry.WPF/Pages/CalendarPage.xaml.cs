﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Blueberry.DLL.Models;
using Blueberry.WPF.UserControls;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages
{
    /// <summary>
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : Page
    {
        private readonly ViewModel _model;
        private ColoredCalendar _calendar;

        public CalendarPage(ViewModel model)
        {
            _model = model;
            InitializeComponent();
            _calendar = new ColoredCalendar(DateTime.Today, _model.Orders);
            Calendar.Content = _calendar;
        }

        private void CalendarPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            _calendar.Refresh();
        }
    }
}
