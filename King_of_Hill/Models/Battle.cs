using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

using MongoDB.Bson;

namespace King_of_Hill.Models
{
    public class Battle
    {
        public Battle()
        {

        }
        public ObjectId id { get; set; }
        [JsonProperty]
        public int ID { get; set; }
        [JsonProperty]
        public string current_king { get; set; }
        [JsonProperty]
        public string challenger { get; set; }
        [JsonProperty]
        public float current_king_time { get; set; }
        [JsonProperty]
        public float challenger_time { get; set; }
        [JsonProperty]
        public string winner { get; set; }
    }
}