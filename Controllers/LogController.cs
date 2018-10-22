using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Common;
using Newtonsoft.Json;
namespace Blog.Controllers
{
    public class LogController : BaseController
    {
        public void SetLog()
        {

        }

        public void threadGet()
        {
            List<Thread> listThread=new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                //Thread t2=new Thread(new ParameterizedThreadStart());
            }

            
        }

        public void GetRedisJson()
        {
            
        }

    }
}