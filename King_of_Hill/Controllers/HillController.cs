using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using King_of_Hill.Models;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

namespace King_of_Hill.Controllers
{
    public class HillController : ApiController
    {
        // GET: api/Hill
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Hill/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hill
        public bool Post([FromBody]Hill hill)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connection);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("koh");
            MongoCollection collection = database.GetCollection<Hill>("Hill");
            //Esto compara si el usuario existe para que no cree un usuario con el mismo username
            bool booleano = collection.AsQueryable<Hill>().Any(x => x.ID == hill.ID);
            if (!booleano)
            {
                collection.Insert(hill);
                return true;
            }
            return false;
        
        }

        // PUT: api/Hill/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hill/5
        public void Delete(int id)
        {
        }
    }
}
