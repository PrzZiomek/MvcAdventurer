using System;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using HtmlAgilityPack;
using MvcAdventurer.Models;


namespace MvcAdventurer.Controllers
{
    class CustomTasks
    {
        public async Task<RootObject> GetWikiApiData()
        {
            var httpClient = HttpClientFactory.Create();
            var url = "https://en.wikipedia.org/w/api.php?action=query&titles=Ukraine&prop=extracts&format=json&exintro=1";

            try
            {
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var content = httpResponseMessage.Content;
                    var data = await content.ReadAsStringAsync();
                    var resJson = JsonConvert.DeserializeObject<RootObject>(data);
                    return resJson;
                }
            }
            catch (HttpRequestException e)
            {
                System.Diagnostics.Debug.WriteLine("\nException Caught!");
                System.Diagnostics.Debug.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }
    }
}
