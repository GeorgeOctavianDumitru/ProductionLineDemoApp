using ProductionLineDemo.ViewModels;
using ProductionLineDemo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProductionLineDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ProductionLineDemo.Views.MainWindow window = new MainWindow();
            MainWindowViewModel VM = new MainWindowViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }
}
