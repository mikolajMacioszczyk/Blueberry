using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Blueberry.DLL;

namespace Blueberry.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            DBConnector.GetInstance().Save();
        }

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            DBConnector.GetInstance().AddException(e.Exception);
            DBConnector.GetInstance().Save();
        }
    }
}
