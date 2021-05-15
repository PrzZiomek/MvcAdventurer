using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAdventurer.Models;


namespace MvcAdventurer.ViewModels
{
    public class RandomCountryViewModel
    {
        public Destination Destination { get; set; }
        public List<Destination> Destinations  { get; set; }
    }
}