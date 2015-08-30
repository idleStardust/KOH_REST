using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

using Newtonsoft.Json;

using King_of_Hill.Models;

namespace King_of_Hill.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public bool Post([FromBody]Users user)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connection);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("koh");
            MongoCollection collection = database.GetCollection<Users>("User");
            //Esto compara si el usuario existe para que no cree un usuario con el mismo username
            bool booleano = collection.AsQueryable<Users>().Any(x => x.username == user.username);
            if (!booleano)
            {
                collection.Insert(user);
                return true;
            }
            return false;
        }

        // PUT: api/Users/5
        public void Put([FromBody]Users user)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connection);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("koh");
            MongoCollection collection = database.GetCollection<Users>("User");
            IQueryable query = collection.AsQueryable<Users>();
            int hill = 0;
            foreach (Users u in query)
            {
                if (u.username == user.username && u.current_hill != user.current_hill)
                {
                    hill = u.current_hill;

                    IMongoQuery queryX = Query<Users>.EQ(e => e.username, user.username);
                    UpdateBuilder<Users> update = Update<Users>.Set(e => e.current_hill, user.current_hill);
                    collection.Update(queryX, update);

                    IMongoQuery query_hill = Query<Hill>.EQ(e => e.ID, hill);
                    UpdateBuilder<Hill> update_hill = Update<Hill>.Set(e => e.occupied, false);
                    collection.Update(query_hill, update_hill);

                    IMongoQuery query_hill_2 = Query<Hill>.EQ(e => e.ID, user.current_hill);
                    UpdateBuilder<Hill> update_hill_2 = Update<Hill>.Set(e => e.occupied, true);
                    collection.Update(query_hill_2, update_hill_2);
                }

            }
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
