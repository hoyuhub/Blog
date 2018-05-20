using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BaseController : Controller
    {
        protected static ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(HttpGlobalExceptionFilter));
    }
}