using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdventurer.Models;
using MvcAdventurer.ViewModels;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using HtmlAgilityPack;


namespace MvcAdventurer.Controllers
{
    public class DestinationsController : Controller
    {
        public async Task<ActionResult> Random()
        {
            var task = new CustomTasks();
            var data = await task.GetWikiApiData();
            var pages = data.query.pages.Values;
            var exstractedPages = pages.Select(x => x.extract).ToList();
            string htmlPage = exstractedPages[0];
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlPage);
            var nodes = doc.DocumentNode.SelectNodes("//p");
            foreach (HtmlNode node in nodes)
                System.Diagnostics.Debug.WriteLine(node.InnerText);

            return Content("here will be soon some random destination");
        }

        [Route("destinations/list")]
        public ActionResult List()
        {

            var viewModel = new DestinationsViewModel
        {
            Destinations = new List<DestinationModel> { },
        };  

            return View(viewModel);
    }


        [Route("destinations/region/{name}")]
        public ActionResult ByRegions(string name)
        {
            return Content(name);
        }
    }
}



