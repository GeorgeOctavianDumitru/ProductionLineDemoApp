using ProductionLineDemoClassLibrary.BusinessLogic.MiR;
using ProductionLineDemoClassLibrary.DataAccessLayer.MiRApi;
using SHIELD.B67.MIR200.ClassLibrary.ControlLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemoClassLibrary.ControlLayer.MiR
{
    public class CheckRobotStatus
    {
        readonly string API = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["ApiAddress"].Value.ToString();

        public bool CheckforError()
        {
            MIR200_GET_API_Data currentState = new MIR200_GET_API_Data(API);
            Debug.WriteLine(currentState.Json.ToString());
            MiR200Status currentStateParsed = new MiR200Status(currentState.Json);

            if (currentStateParsed != null)
            {
                if (currentStateParsed.state_id == 12)
                {
                    string message = $"AGV Status is {currentStateParsed.state_id} that means it is in {currentStateParsed.state_text}. This is due to {currentStateParsed.mission_text}";
                    ConfirmationEmail.send("George", "octavian.d.g@gmail.com.com", "robotService@gmail.com", "Error Notification", message);
                    return true;
                }

                else if (currentStateParsed.state_id == 10)
                {
                    string message = $"AGV Status is {currentStateParsed.state_id} that means it is in {currentStateParsed.state_text}. This is due to {currentStateParsed.mission_text}";
                    ConfirmationEmail.send("George", "octavian.d.g@gmail.com.com", "robotService@gmail.com", "Error Notification", message);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                string message = $"Urgent! The MONITOR APP could not connect to the MiR200 <{API}>. Urgent attention is required! ";
                ConfirmationEmail.send("George", "octavian.d.g@gmail.com.com", "robotService@gmail.com", "Error Notification", message);
                return false;

            }
        }
    }
}
