using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class WordController : ApiController
    {
        // GET: api/Word
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Word/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Word
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Word/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Word/5
        public void Delete(int id)
        {
        }
    }
}
