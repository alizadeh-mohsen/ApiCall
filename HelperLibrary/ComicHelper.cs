using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class ComicHelper
    {
        private string comicBaseUrl = "https://xkcd.com";
        public ComicHelper()
        {
            ApiHelper.InitializeApiHelper();

        }

        public async Task<ComicModel> LoadComicImage(int comicNumber = 0)
        {
            var url = comicNumber == 0 ? $"{comicBaseUrl}/info.0.json" : $"{comicBaseUrl}/{comicNumber}/info.0.json";

            using (HttpResponseMessage response = await ApiHelper.HttpClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    return comic;
                }
                throw new Exception(response.ReasonPhrase);

            }
        }
    }
}
