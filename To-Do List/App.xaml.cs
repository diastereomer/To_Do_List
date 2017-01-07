using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
namespace To_Do_List
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartUp(object sender, StartupEventArgs e)
        {
            Infrastructures.Factory factory = new Infrastructures.Factory();
            Infrastructures.Infrastructure infrastructure = factory.Create("login");
            infrastructure.View.DataContext = infrastructure.ViewModel;
            infrastructure.View.Show();
        }
    }
}
