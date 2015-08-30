using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

using MongoDB.Bson;

namespace King_of_Hill.Models
{
    public class Hill
    {
        public Hill()
        {

        }
        public ObjectId id { get; set; }
        [JsonProperty]
        public int ID { get; set; }
        [JsonProperty]
        public string king { get; set; }
        [JsonProperty]
        public bool occupied { get; set; }
        [JsonProperty]
        public float lat_a { get; set; }
        [JsonProperty]
        public float lat_b { get; set; }
        [JsonProperty]
        public float long_a { get; set; }
        [JsonProperty]
        public float long_b { get; set; }
        [JsonProperty]
        public bool battle { get; set; }
    }
}