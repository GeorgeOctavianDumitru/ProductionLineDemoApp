using ProductionLineDemo.Models;
using ProductionLineDemo.ViewModels.Commands;
using ProductionLineDemoClassLibrary.BusinessLogic.Production;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemo.ViewModels
{
    public class ProductionScheduleViewModel:BaseViewModel,INotifyPropertyChanged
    {
        public ProductionScheduleViewModel()
        {
            FetchPlan = new RelayCommand(cmd_populatePlan);
            
        }
        #region Properties
        
        public RelayCommand FetchPlan { get; private set; }
        //public ObservableCollection<ProductionSchedule> Plan { get; private set; }

        private ObservableCollection<ProductionSchedule> _plan;

        public ObservableCollection<ProductionSchedule> Plan
        {
            get { return _plan; }
            set { _plan = value; OnPropertyChanged(nameof(Plan)); }
        }


        #endregion
        #region Methods

        public void cmd_populatePlan(object message)
        {
            ProductionSchedule schedule = new ProductionSchedule();
                        
            Plan=new ObservableCollection<ProductionSchedule>(schedule.GetSchedule() as List<ProductionSchedule>);
        }

        #endregion



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
    }
}
