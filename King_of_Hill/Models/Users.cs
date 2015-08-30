using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Driver;

using Newtonsoft.Json;

namespace King_of_Hill.Models
{
    public class Users
    {
        public Users()
        {
        }
        public  ObjectId id { get; set; }
        [JsonProperty]
        public string username { get; set; }
        [JsonProperty]
        public string password { get; set; }
        [JsonProperty]
        public string question { get; set; }
        [JsonProperty]
        public string answer { get; set; }
        [JsonProperty]
        public string school { get; set; }
        [JsonProperty]
        public int current_hill { get; set; }
    }
}