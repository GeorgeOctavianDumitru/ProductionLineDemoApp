using ProductionLineDemo.Models;
using ProductionLineDemo.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemo.ViewModels
{
    public class SettingsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
            ConnectionString = GetConnectionString();
            ModBusIp = GetSettingsModel().ModBusIp;
            ApiAddress = GetSettingsModel().ApiAddress;
            VisualInstructionRoot = GetSettingsModel().VisualInstructionRoot;
            SaveSettings = new RelayCommand(UpdateSettings);
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

        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                _connectionString = value;
                OnPropertyChanged(nameof(ConnectionString));
            }
        }

        private string _modbusIp;

        public string ModBusIp
        {
            get { return _modbusIp; }
            set { _modbusIp = value; OnPropertyChanged(nameof(ModBusIp)); }
        }
        private string _apiAddress;

        public string ApiAddress
        {
            get { return _apiAddress; }
            set { _apiAddress = value; OnPropertyChanged(nameof(ApiAddress)); }
        }
        private string _visualInstructionRoot;

        public string VisualInstructionRoot
        {
            get { return _visualInstructionRoot; }
            set { _visualInstructionRoot = value; OnPropertyChanged(nameof(VisualInstructionRoot)); }
        }


        public RelayCommand SaveSettings { get; private set; }


        #endregion

        #region Methods
        public string GetConnectionString()
        {
            string connectionString;
            //Get the file path
            Configuration config = ConfigurationManager.OpenExeConfiguration($"");
            //Get Value of the Setting
            connectionString = ConfigurationManager.ConnectionStrings["DemoDB_ConnectionString"].ConnectionString;
            return connectionString;

        }
        public SettingsModel GetSettingsModel()
        {
             SettingsModel settingsModel = new SettingsModel();
            settingsModel.ModBusIp = ConfigurationManager.AppSettings["ModbusIp"];
            settingsModel.ApiAddress = ConfigurationManager.AppSettings["ApiAddress"];
            settingsModel.VisualInstructionRoot = ConfigurationManager.AppSettings["VisualInstructionRoot"];
            return settingsModel;
        }

        public void UpdateSettings(object message)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["ModbusIp"].Value = ModBusIp;
            config.AppSettings.Settings["ApiAddress"].Value = ApiAddress;
            config.AppSettings.Settings["VisualInstructionRoot"].Value = VisualInstructionRoot;
            config.ConnectionStrings.ConnectionStrings["DemoDB_ConnectionString"].ConnectionString = ConnectionString;
            config.Save(ConfigurationSaveMode.Modified);
            Debug.WriteLine("Saved");
            ConfigurationManager.RefreshSection("appSettings");
            string activeFile;
            activeFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            Debug.WriteLine(activeFile);
            
        }
        #endregion  
    }
}
