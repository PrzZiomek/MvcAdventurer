using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcAdventurer.Models
{
    [Table("countries")]
    public class DestinationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Characteristic { get; set; }
        public string History { get; set; }
        public JArray Images { get; set; }

        public override string ToString()
        {
            return $"{{ 'Id': {Id} 'Name': {Name}, 'Characteristic': {Characteristic}, 'History': {History} }}";
        }
    }
}

