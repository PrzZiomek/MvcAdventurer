using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MvcAdventurer.Models;
using System.Net;
using Newtonsoft.Json;
using HtmlAgilityPack;

namespace MvcAdventurer.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
             var task = new DestinationsController();
               var data = await task.GetDestinationData("Miami");
           // var task = new CustomTasks();
         //   var data = await task.CallWikiApiData("Miami");
         //   var pages = data.Root.query.pages.Values;
         //   var images = data.Images;
            /*  dynamic co = data.Coordinates[0];
              var coordinates = new {
                  lat = co.lat,
                  lon = co.lon 
              }; */
            System.Diagnostics.Debug.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            System.Diagnostics.Debug.WriteLine(data);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }

}


