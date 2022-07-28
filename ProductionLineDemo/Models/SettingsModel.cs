using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemo.Models
{
    public class SettingsModel
    {
        private string _modbusIp;

        public string ModBusIp
        {
            get { return _modbusIp; }
            set { _modbusIp = value; }
        }
        private string _apiAddress;

        public string ApiAddress
        {
            get { return _apiAddress; }
            set { _apiAddress = value; }
        }
        private string _visualInstructionRoot;

        public string VisualInstructionRoot
        {
            get { return _visualInstructionRoot; }
            set { _visualInstructionRoot = value; }
        }



    }
}
