using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataLibrary.Models
{
    [Table("countries")]
    public class DestinationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string History { get; set; }
        public string Characteristic { get; set; }

        public override string ToString()
        {
            return $"{{ 'Id': {Id} 'Name': {Name}, 'Characteristic': {Characteristic}, 'History': {History} }}";
        }
    }
}
