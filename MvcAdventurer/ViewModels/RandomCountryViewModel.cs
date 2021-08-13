using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary.Models;


namespace MvcAdventurer.ViewModels
{
    public class RandomCountryViewModel
    {
        public DestinationModel Destination { get; set; }
        public List<DestinationModel> Destinations  { get; set; }
    }
}