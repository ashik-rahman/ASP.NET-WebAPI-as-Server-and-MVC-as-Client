using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Mvc
{
    public static class GlobalVariables
    {
        public static HttpClient webApiClient = new HttpClient();
        static GlobalVariables()
        {
            webApiClient.BaseAddress = new Uri("http://localhost:64017/api/");
            webApiClient.DefaultRequestHeaders.Clear();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}