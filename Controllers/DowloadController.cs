using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseUtils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    public class DowloadController : Controller
    {

        private CnblogDAL CnblogDal { get; }
        private RedisCommon RedisCommon { get; }
        public DowloadController(CnblogDAL cnblogDal, RedisCommon redisCommon)
        {
            this.CnblogDal = cnblogDal;
            this.RedisCommon = redisCommon;
        }
        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            Dictionary<string, object> resultDic = new Dictionary<string, object>();
            bool result = false;
            string error = string.Empty;
            try
            {
                int count = CnblogDal.GetCount();

                int forCount = (count / 100) + (count % 100 == 0 ? 0 : 1);
                for (int i = 1; i < forCount + 1; i++)
                {
                    List<Cnblog> cnBlogList = CnblogDal.GetPage(i);
                    DownloadHtml(cnBlogList);
                }
                result = true;

            }
            catch (Exception e)
            {
                error = e.Message;
            }

            resultDic.Add("result", result);
            if (!result) resultDic.Add("error", error);
            return JsonConvert.SerializeObject(resultDic);
        }

        public bool DownloadHtml(List<Cnblog> list)
        {

            foreach (var item in list)
            {
                try
                {

                    WebClient webClient = new WebClient();
                    Uri uri = new Uri(item.Href);
                    RedisCommon.GetData().HashSet("cnblog:html", item.Id, webClient.DownloadString(uri));
                }
                catch (Exception e)
                {
                    //TODO log

                }
            }
            return true;
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
