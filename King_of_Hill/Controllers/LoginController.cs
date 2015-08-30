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
    public class LoginController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public bool Post([FromBody] Users user)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connection);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("koh");
            MongoCollection collection = database.GetCollection<Users>("User");
            bool booleano = collection.AsQueryable<Users>().Any(x => (x.username == user.username) && (x.password == user.password));
            if (booleano)
            {
                return true;
            }
            return false;
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
