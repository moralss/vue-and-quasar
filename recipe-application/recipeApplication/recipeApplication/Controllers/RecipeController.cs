using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace recipeApplication.Controllers
{
    public class RecipeController : ApiController
    {
        // GET: api/Recipe
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Recipe/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Recipe
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Recipe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recipe/5
        public void Delete(int id)
        {
        }
    }
}
