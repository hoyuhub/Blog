using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseUtils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    public class DowloadController : Controller
    {

        private MySqlDbContext DbContext;
        public DowloadController(MySqlDbContext mysqlDb)
        {
            this.DbContext = mysqlDb;
        }
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(DbContext.Cnblogs.Skip(10 * (1 - 1)).Take(10).ToList());

            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
