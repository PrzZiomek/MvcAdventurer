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
            var pages = data.Root.query.pages.Values;
            var exstractedPages = pages.Select(x => x.extract).ToList();
            string htmlPage = exstractedPages[0];
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlPage);
            var nodes = doc.DocumentNode.SelectNodes("//p");
            var nodesCont = nodes.Select(x => x.InnerText).ToArray();
            string name = nodesCont[2].Split(' ')[0];     //    System.Diagnostics.Debug.WriteLine(nodesCont[2]);
            var images = data.Images;

            var destModel = new DestinationModel
                 {
                     Name =  name,
                     History = string.Concat(nodesCont[3], nodesCont[4]),
                     Characteristic = nodesCont[5],
                     Images = images
                 };
           
             return View(destModel); 
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
    }
}



