using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseUtils;

namespace Blog.Controllers
{
    public class BlogController : BaseController
    {
        public BlogController(CnblogDAL cnblogDal, RedisCommon redisCommon) : base(cnblogDal, redisCommon)
        {

        }

        //主页
        public IActionResult Home()
        {
            var cnblogs = CnblogDal.GetPage(1, 10);
            return View(cnblogs);
        }

        public IActionResult Blog(string id)
        {
            ViewData["html"] = this.RedisCommon.GetData().HashGet("cnblog:html", id);
            return View();
        }

    }
}