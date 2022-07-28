using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemoClassLibrary.DataAccessLayer
{
    public class ModbusMaster
    {

        private int[] _holdingRegisters;

        public int[] HoldingRegisters
        {
            get { return _holdingRegisters; }
            set { _holdingRegisters = value; }
        }

        private bool[] _discreteInputs;

        public bool[] DiscreteInputs
        {
            get { return _discreteInputs; }
            set { _discreteInputs = value; }
        }

        private float _regToFLoat;

        public float RegToFloat
        {
            get { return _regToFLoat; }
            set { _regToFLoat = value; }
        }

        //This class is created using the EasyModbus NuGet package. 

        ModbusClient plc = new ModbusClient();

        public bool ConnectionStatus(string ipAddress, int port)
        {

            plc.IPAddress = ipAddress;
            plc.Port = Convert.ToInt32(port);
            plc.Connect();
            if (plc.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ModbusMaster ReadAll(int startPosition, int length,int startDisPosition, int dis_length)
        {
            ModbusMaster master = new ModbusMaster();
            master.HoldingRegisters = plc.ReadHoldingRegisters(startPosition, length);
            master.DiscreteInputs=plc.ReadDiscreteInputs(startDisPosition, dis_length);
            master.RegToFloat = ModbusClient.ConvertRegistersToFloat(master.HoldingRegisters);
            return master;
        }

        public void WriteRegister(int StartingAddress, int value)
        {
            plc.WriteSingleRegister(StartingAddress, value);
        }

        public void WriteCoil(int StartingAddress, bool value)
        {
            plc.WriteSingleCoil(StartingAddress, value);
        }
    }
}
