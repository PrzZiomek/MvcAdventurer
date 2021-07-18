using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MvcAdventurer.Models
{
    public class DestinationContext: DbContext
    {
        public DbSet<DestinationModel> Destinations { get; set;  }
    }
}