using System;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using HtmlAgilityPack;
using MvcAdventurer.Models;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace MvcAdventurer.Controllers
{
    class CustomTasks
    {
        public async Task<WikiApiResponseObj> CallWikiApiData(string name)
        {   
            string pageUrl = $"https://en.wikipedia.org/w/api.php?action=query&titles={name}&prop=extracts&format=json&exintro=1";
            string pageImagesUrl = $"https://en.wikipedia.org/w/api.php?action=query&titles={name}&prop=images&format=json";
            string pageCoordinatesUrl = $"https://en.wikipedia.org/w/api.php?action=query&titles={name}&prop=coordinates&format=json";

            try
            {
                var res = await getApiResponse<RootResObject>(pageUrl);
                var imagesRes = await getApiResponse<ImageResObject>(pageImagesUrl);
                var coordinatesRes = await getApiResponse<CoordinatesResObject>(pageCoordinatesUrl);

                int pageId = res.query.pages.Values.Single().pageid;
                var images = imagesRes.query.pages
                  .Value<JObject>(pageId.ToString())
                  .Value<JArray>("images");
                var coordinates = coordinatesRes.query.pages
                  .Value<JObject>(pageId.ToString())
                  .Value<JArray>("coordinates");

                var responseObj = new WikiApiResponseObj
                {
                    Root = res,
                    Images = images,
                    Coordinates = coordinates 
                };

                return responseObj;
            }
            catch (HttpRequestException e)
            {
                System.Diagnostics.Debug.WriteLine("\nException Caught!");
                System.Diagnostics.Debug.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }
 
        private async Task<T> getApiResponse<T>(string pageUrl)
        {
            var httpClient = HttpClientFactory.Create();
            HttpResponseMessage httpResponseMsg = await httpClient.GetAsync(pageUrl);
            if (httpResponseMsg.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMsg.Content;
                var data = await content.ReadAsStringAsync();
                var resJson = JsonConvert.DeserializeObject<T>(data);
                return resJson;
            }
            return default(T);
        }
    }
}