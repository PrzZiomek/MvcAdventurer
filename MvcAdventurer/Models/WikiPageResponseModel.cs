using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace MvcAdventurer.Models
{


    public class PageVal
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }
    }

     public class Query
    {
        public Dictionary<string, PageVal> pages { get; set; }

    }
    public class QueryImg
    {
        public JObject pages { get; set; }

    }

    public class QueryCoordinates
    {
        public JObject pages { get; set; }

    }

    public class Limits
    {
        public int extracts { get; set; }
    }

    public class RootResObject
    {
        public string batchcomplete { get; set; }
        public Query query { get; set; }
        public Limits limits { get; set; }

    }

    public class ImageResObject
    {
        public QueryImg query { get; set; }
    }

    public class CoordinatesResObject
    {
        public QueryCoordinates query { get; set; }
    }

    public class WikiApiResponseObj
    {
        public RootResObject Root { get; set; }
        public JArray Images { get; set; }
        public JArray Coordinates { get; set; }
    }
}