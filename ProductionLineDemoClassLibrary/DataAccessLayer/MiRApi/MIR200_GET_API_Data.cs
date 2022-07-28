using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLineDemoClassLibrary.DataAccessLayer.MiRApi
{
    public class MIR200_GET_API_Data
    {
        #region properties
        private string _json;

        public string Json
        {
            get { return _json; }
            set { _json = value; }
        }
        #endregion


        #region Constructors
        public MIR200_GET_API_Data(string APIURL)
        {
            Json = Task.Run(async () => await GetAPIDataAsync(APIURL)).Result.ToString();
        }
        #endregion


        #region Methods
        static async Task<string> GetAPIDataAsync(string APIURL)
        {
            using (var client = new HttpClient())
            {
                string uri = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["MIR200_IP"].Value.ToString();
                string credentials = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["MIR200_authentication"].Value.ToString();
                try
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    string authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

                    #region Consume GET Method
                    HttpResponseMessage response = await client.GetAsync(APIURL);

                    if (response.IsSuccessStatusCode)
                    {
                        string httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                        string json = httpResponseResult;


                        return json;
                    }
                    else
                    {
                        return $"Internal server error! Could not connect to {uri + APIURL}";
                    }

                    #endregion

                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }
        #endregion
    }
}
