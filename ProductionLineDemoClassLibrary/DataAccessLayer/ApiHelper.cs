using System.Net.Http;
using System.Net.Http.Headers;

namespace ProductionLineDemoClassLibrary.DataAccessLayer
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }    

        public static void InitializeClient(string authInfo)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
        }
    }
    
    
}
