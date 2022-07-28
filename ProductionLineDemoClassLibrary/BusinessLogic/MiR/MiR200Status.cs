using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemoClassLibrary.BusinessLogic.MiR
{
    public class MiR200Status
    {
        #region Properties
        public string Joystick_low_speed_mode_enabled { get; set; }
        public string mission_queue_url { get; set; }
        public int mode_id { get; set; }
        public double moved { get; set; }

        public int? mission_queue_id { get; set; }
        public string robot_name { get; set; }
        public string joystick_web_session_id { get; set; }
        public int uptime { get; set; }
        public string errors { get; set; }
        public string unloaded_map_changes { get; set; }
        public int distance_to_next_target { get; set; }
        public string serial_number { get; set; }
        public string mode_key_state { get; set; }
        public int battery_percentage { get; set; }
        public string map_id { get; set; }
        public string safety_system_muted { get; set; }
        public string mission_text { get; set; }
        public string state_text { get; set; }
        public string footprint { get; set; }
        public string user_prompt { get; set; }
        public string allowed_methods { get; set; }
        public string robot_model { get; set; }
        public string mode_text { get; set; }
        public string session_id { get; set; }
        public int state_id { get; set; }
        public int battery_time_remaining { get; set; }
        public string position { get; set; }
        public string velocity { get; set; }
        public bool checkError { get; set; }


        #endregion

        #region Constructors
        public MiR200Status(string json2)
        {
            JObject jObject = JObject.Parse(json2);
            Joystick_low_speed_mode_enabled = jObject["joystick_low_speed_mode_enabled"].ToString();
            mission_queue_url = jObject["mission_queue_url"].ToString();
            mode_id = Convert.ToInt32(jObject["mode_id"]);
            moved = Convert.ToDouble(jObject["moved"]);
            //mission_queue_id = Convert.ToInt32(jObject["mission_queue_id"]);
            robot_name = jObject["robot_name"].ToString();
            joystick_web_session_id = jObject["joystick_web_session_id"].ToString();
            uptime = Convert.ToInt32(jObject["uptime"]);
            errors = jObject["errors"].ToString();
            unloaded_map_changes = jObject["unloaded_map_changes"].ToString();
            distance_to_next_target = Convert.ToInt32(jObject["distance_to_next_target"]);
            serial_number = jObject["serial_number"].ToString();
            mode_key_state = jObject["mode_key_state"].ToString();
            battery_percentage = Convert.ToInt32(jObject["battery_percentage"]);
            map_id = jObject["map_id"].ToString();
            safety_system_muted = jObject["safety_system_muted"].ToString();
            mission_text = jObject["mission_text"].ToString();
            state_text = jObject["state_text"].ToString();
            footprint = jObject["footprint"].ToString();
            user_prompt = jObject["user_prompt"].ToString();
            allowed_methods = jObject["allowed_methods"].ToString();
            robot_model = jObject["robot_model"].ToString();
            mode_text = jObject["mode_text"].ToString();
            session_id = jObject["session_id"].ToString();
            state_id = Convert.ToInt32(jObject["state_id"]);
            battery_time_remaining = Convert.ToInt32(jObject["battery_time_remaining"]);
            position = jObject["position"].ToString();
            velocity = jObject["velocity"].ToString();
            state_text = jObject["state_text"].ToString();

            checkError = (state_text == "True")
            if (jObject["mission_queue_id"] == null || jObject["mission_queue_id"].Type == JTokenType.Null)
            {
                mission_queue_id = 0;
                mission_queue_url = "No Missions in the queue";
            }
            else
            {
                mission_queue_id = Convert.ToInt32(jObject["mission_queue_id"]);
            }
        }
        public MiR200Status()
        {

        }
        #endregion
    }
}
