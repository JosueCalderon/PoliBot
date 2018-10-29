using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class LanguageController : ApiController
    {
        // GET: api/Language
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Language/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Language
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Language/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Language/5
        public void Delete(int id)
        {
        }
    }
}
