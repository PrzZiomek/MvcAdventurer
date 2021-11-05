using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models; 
using MvcAdventurer.ViewModels;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;


namespace MvcAdventurer.Controllers
{
    public class DestinationsController : Controller
    {
        public async Task<ActionResult> Random()
        {
            await GetDestinationData("Ukraine");

            return View(); 
        }

        [Route("destinations/list")]
        public ActionResult List()
        {         
            return Content("here will be the list of dests");
        }


        [Route("destinations/region/{name}")]
        public ActionResult ByRegions(string name)
        {
            return Content(name);
        }

        public async Task<object> GetDestinationData(string name)
        {
            var task = new CustomTasks();
            var data = await task.CallWikiApiData(name);
            var pages = data.Root.query.pages.Values;
            var images = data.Images;
            dynamic co = data.Coordinates[0];
            var coordinates = new {
                lat = co.lat,
                lon = co.lon 
            }; 
            var exstractedPages = pages.Select(x => x.extract).ToList();
            string htmlPage = exstractedPages[0];
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlPage);
            var nodes = doc.DocumentNode.SelectNodes("//p");
            string[] nodesCont = nodes.Select(x => x.InnerText).ToArray();
            var destination = new {
                Characteristic = string.Join<string>(" ", nodesCont),
                Images = images,
                Coordinates = coordinates
            };

            return destination;
        }
    }
}



