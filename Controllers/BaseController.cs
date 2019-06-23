using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseUtils;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class BaseController : Controller
    {
        protected static ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(HttpGlobalExceptionFilter));
        protected CnblogDAL CnblogDal { get; }
        protected RedisCommon RedisCommon { get; }
        public BaseController(CnblogDAL cnblogDal, RedisCommon redisCommon)
        {
            this.CnblogDal = cnblogDal;
            this.RedisCommon = redisCommon;
        }
    }
}