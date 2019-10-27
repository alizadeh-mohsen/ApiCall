using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class SunHelper
    {
        private string baseUrl = "https://api.sunrise-sunset.org/json?";
        public SunHelper()
        {
            ApiHelper.InitializeApiHelper();
        }

        public async Task<SunModel> LoadSunInfo(double lat, double lng)
        {
            var url = $"{baseUrl}lat={lat}&lng={lng}";

            using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var sunModel = await response.Content.ReadAsAsync<SunModel>();
                    return sunModel;
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}
