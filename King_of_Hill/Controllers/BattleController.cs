using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace King_of_Hill.Controllers
{
    public class BattleController : ApiController
    {
        // GET: api/Battle
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Battle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Battle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Battle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Battle/5
        public void Delete(int id)
        {
        }
    }
}
