using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Common;

namespace Blog.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            //RedisCommon.SetBLog(new BLogModel("标题","小猿",DateTime.Now,"这里的山路十八弯"));
            // Dictionary<string, string> dictionary = RedisCommon.GetConnection().GetDatabase().HashGetAll("weather:WJX5GH5PYG5R").ToDic();
            RedisCommon.SetSlugToId("testtest","test");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
