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
    public class CurrentHillController : ApiController
    {
        // GET: api/CurrentHill
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CurrentHill/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CurrentHill
        public void Post([FromBody]Users user)
        {
            string connection = "mongodb://localhost:27017";
            MongoClient client = new MongoClient(connection);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("koh");
            MongoCollection collection = database.GetCollection<Users>("User");
            MongoCollection collection_2 = database.GetCollection<Hill>("Hill");
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
                    collection_2.Update(query_hill, update_hill);

                    IMongoQuery query_hill_2 = Query<Hill>.EQ(e => e.ID, user.current_hill);
                    UpdateBuilder<Hill> update_hill_2 = Update<Hill>.Set(e => e.occupied, true);
                    collection_2.Update(query_hill_2, update_hill_2);

                    IQueryable query_battle = collection.AsQueryable<Hill>();
                    foreach (Hill h in query_battle)
                    {
                        if (h.ID == user.current_hill)
                        {
                            if (h.battle)
                            {

                            }
                        }
                    }
                }

            }
        }

        // PUT: api/CurrentHill/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CurrentHill/5
        public void Delete(int id)
        {
        }
    }
}
