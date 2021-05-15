using MvcAdventurer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdventurer.ViewModels;



namespace MvcAdventurer.Controllers
{
    public class DestinationsController : Controller
    {
        public ActionResult Random()
        {
           
            //    System.Diagnostics.Debug.WriteLine("RFFfdf");
            return Content("here will be some random destination");
        }

        [Route("destinations/list")]
        public ActionResult List()
        {
            var country1 = new Destination() { Name = "Syria" };
            var country2 = new Destination() { Name = "Palestine" };
            var country3 = new Destination() { Name = "Poland" };
            var viewModel = new DestinationsViewModel
            {
                Destinations = new List<Destination> { country1, country2, country3 },

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



