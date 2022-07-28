using ProductionLineDemoClassLibrary.BusinessLogic.Production;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemo.Models
{
    public class ProductionScheduleModel : INotifyPropertyChanged
    {
        #region Properties
        private string _orderNumber;

        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; OnPropertyChanged(nameof(OrderNumber)); }
        }
        private string _productNumber;

        public string ProductNumber
        {
            get { return _productNumber; }
            set { _productNumber = value; OnPropertyChanged(nameof(ProductNumber)); }
        }
        private int _orderQty;

        public int OrderQty
        {
            get { return _orderQty; }
            set { _orderQty = value; OnPropertyChanged(nameof(OrderQty)); }
        }
        private string _customer;

        public string Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(nameof(Customer)); }
        }
        private string _workCentre;

        public string WorkCentre
        {
            get { return _workCentre; }
            set { _workCentre = value; OnPropertyChanged(nameof(WorkCentre)); }
        }
        private string _capacityGroup;

        public string CapacityGroup
        {
            get { return _capacityGroup; }
            set { _capacityGroup = value; OnPropertyChanged(nameof(CapacityGroup)); }
        }
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        private IList<ProductionScheduleModel> _myPlan;

       


        #endregion

        #region Methods

        

        #endregion

        #region Constructors

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
