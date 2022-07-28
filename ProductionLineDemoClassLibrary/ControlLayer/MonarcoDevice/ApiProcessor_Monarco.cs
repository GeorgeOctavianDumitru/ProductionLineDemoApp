using ProductionLineDemoClassLibrary.BusinessLogic.Monarco;
using ProductionLineDemoClassLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static ProductionLineDemoClassLibrary.BusinessLogic.Monarco.CounterSubitem;

namespace ProductionLineDemoClassLibrary.ControlLayer.MonarcoDevice
{
    public class ApiProcessor_Monarco
    {
        public static async Task<Display> GetDisplayValue(string url)
        {
            string credentials = "admin:";
            string authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            ApiHelper.InitializeClient(authInfo);
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Display display = await response.Content.ReadAsAsync<Display>();
                    return display;
                }
                throw new Exception(response.ReasonPhrase);
            }
        }
        public static async Task<CounterBlock> GetCounterBlock(string url)
        {
            string credentials = "admin:";
            string authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            ApiHelper.InitializeClient(authInfo);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    CounterBlock counterBlock = await response.Content.ReadAsAsync<CounterBlock>();
                    return counterBlock;
                }
                throw new Exception(response.ReasonPhrase);
            }

        }

        public static async Task<SETH> PostCounterBlock(string url, object mission)
        {
            string credentials = "admin:";
            string authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
            ApiHelper.InitializeClient(authInfo);

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(url, mission))
            {
                if (response.IsSuccessStatusCode)
                {
                    SETH setCounter = await response.Content.ReadAsAsync<SETH>();
                    return setCounter;
                }
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
