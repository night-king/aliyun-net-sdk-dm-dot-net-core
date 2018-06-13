using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Deepleo.Aliyun.DM.Models;
using System.Diagnostics;

namespace Deepleo.Aliyun.DM.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}