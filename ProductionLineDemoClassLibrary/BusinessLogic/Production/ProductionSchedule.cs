using ProductionLineDemoClassLibrary.DataAccessLayer;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProductionLineDemoClassLibrary.BusinessLogic.Production
{
    public class ProductionSchedule
    {
        #region Properties
        private string _orderNumber;

        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; }
        }
        private string _productNumber;

        public string ProductNumber
        {
            get { return _productNumber; }
            set { _productNumber = value; }
        }
        private int _orderQty;

        public int OrderQty
        {
            get { return _orderQty; }
            set { _orderQty = value; }
        }
        private string _customer;

        public string Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }
        private string _workCentre;

        public string WorkCentre
        {
            get { return _workCentre; }
            set { _workCentre = value; }
        }
        private string _capacityGroup;

        public string CapacityGroup
        {
            get { return _capacityGroup; }
            set { _capacityGroup = value; }
        }
        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion

        #region Methods

        public List<ProductionSchedule> GetSchedule()
        {
            List<ProductionSchedule> schedule = new List<ProductionSchedule>();
            ADO_DAL Database = new ADO_DAL();
            Database.ConnectionString = ConfigurationManager.ConnectionStrings["DemoDB_ConnectionString"].ConnectionString;
            string SP = $"dbo.GetProductionSchedule";
            DataTable dtProductionPlan = Database.Exec_SELECT(SP, true, false);
            if(dtProductionPlan.Rows.Count > 0)
            {
                for (int i = 0; i < dtProductionPlan.Rows.Count; i++)
                {
                    ProductionSchedule job = new ProductionSchedule()
                    {
                        OrderNumber = dtProductionPlan.Rows[i]["OrderNumber"].ToString(),
                        ProductNumber = dtProductionPlan.Rows[i]["ProductNumber"].ToString(),
                        OrderQty = Convert.ToInt32(dtProductionPlan.Rows[i]["OrderQty"]),
                        Customer = dtProductionPlan.Rows[i]["Customer"].ToString(),
                        WorkCentre = dtProductionPlan.Rows[i]["Work Center Description"].ToString(),
                        CapacityGroup = dtProductionPlan.Rows[i]["CapacityGroupName"].ToString(),
                        Status = dtProductionPlan.Rows[i]["StatusDescription"].ToString()

                    };
                    schedule.Add(job);
                }

                return schedule;
            }
            return null;
        }


        public List<ProductionSchedule> GetOrderByOrderNumber(string OrderNumber)
        {
            List<ProductionSchedule> schedule = new List<ProductionSchedule>();
            ADO_DAL Database = new ADO_DAL();
            Database.ConnectionString = ConfigurationManager.ConnectionStrings["DemoDB_ConnectionString"].ConnectionString;
            string SP = $"dbo.GetProductionSchedule";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@OrderNumber", OrderNumber));
            DataTable dtProductionPlan = Database.Exec_SELECT(SP, true, true, sqlParameters);
            if (dtProductionPlan.Rows.Count > 0)
            {
                for (int i = 0; i < dtProductionPlan.Rows.Count; i++)
                {
                    ProductionSchedule job = new ProductionSchedule()
                    {
                        OrderNumber = dtProductionPlan.Rows[i]["OrderNumber"].ToString(),
                        ProductNumber = dtProductionPlan.Rows[i]["ProductNumber"].ToString(),
                        OrderQty = Convert.ToInt32(dtProductionPlan.Rows[i]["OrderQty"]),
                        Customer = dtProductionPlan.Rows[i]["Customer"].ToString(),
                        WorkCentre = dtProductionPlan.Rows[i]["Work Center Description"].ToString(),
                        CapacityGroup = dtProductionPlan.Rows[i]["CapacityGroupName"].ToString(),
                        Status = dtProductionPlan.Rows[i]["StatusDescription"].ToString()

                    };
                    schedule.Add(job);
                }

                return schedule;
            }
            return null;
        }

        #endregion


    }
}
