using ProductionLineDemo.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProductionLineDemo.ViewModels
{
    public class MainWindowViewModel :BaseViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<string> MyMessages { get; private set; }
        private BaseViewModel _selectedViewModel = new StartViewModel();

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set 
            {
                _selectedViewModel = value; 
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }


        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        #region Properties

        public CloseCommand CloseCommand { get; set; }
        public CloseCommand MaximizeCommand { get; private set; }
        public CloseCommand MinimizeCommand { get; private set; }

        public RelayCommand MessageBoxCommand { get; private set; }
        public RelayCommand ConsoleCommand { get; private set; }
        public RelayCommand cmdUpdateViewModel { get;private set; }

        #endregion


        public MainWindowViewModel()
        {

            CloseCommand = new CloseCommand(appClose);
            MaximizeCommand = new CloseCommand(maximizeWindow);
            MinimizeCommand = new CloseCommand(minimizeWindow);


            MyMessages = new ObservableCollection<string>
            {
                "Hello World",
                "My name is George!",
                "I'm a messageBox!",
                "I am in console"
            };

            MessageBoxCommand = new RelayCommand(DisplayInMessageBox, MessageBoxCanUSe);
            ConsoleCommand = new RelayCommand(DispalyInConsole, ConsoleBoxCanUSe);
            cmdUpdateViewModel = new RelayCommand(UpdateViewModel);
        }

        public void DisplayInMessageBox(object message)
        {
            MessageBox.Show((string)message);
        }
        public void DispalyInConsole(object message)
        {
            Debug.WriteLine((string)message);
        }

        public bool MessageBoxCanUSe(object message)
        {
            return ((string)message!= "I am in console");
        }
        public bool ConsoleBoxCanUSe(object message)
        {
            return ((string)message != "I'm a messageBox!");
        }

        public void UpdateViewModel(object message)
        {
            switch ((string)message) {
                case "Start":
                    SelectedViewModel = new StartViewModel();
                    break;
                case "Settings":
                    SelectedViewModel = new SettingsViewModel();
                    break;
                case "Schedule":
                    SelectedViewModel = new ProductionScheduleViewModel();
                    break;
                case "TestingEq":
                    SelectedViewModel = new TestingEqViewModel();
                    break;
                case "Dashboards":
                    SelectedViewModel = new DashboardsViewModel();
                    break;
                default:
                    SelectedViewModel = null;
                    break;
            }
        }
        
        #region ChromaBtns
        private void appClose()
        {
            App.Current.MainWindow.Close();
            //App.Current.Windows[0].WindowState = System.Windows.WindowState.Maximized;
        }

        private void maximizeWindow()
        {
            if (App.Current.MainWindow.WindowState == System.Windows.WindowState.Normal)
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                App.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            }
        }

        private void minimizeWindow()
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion


    }
}
