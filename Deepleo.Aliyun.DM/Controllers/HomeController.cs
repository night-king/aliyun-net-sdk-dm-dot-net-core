using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Deepleo.Aliyun.DM.Models;

namespace Deepleo.Aliyun.DM.Controllers
{
    public class HomeController : Controller
    {
        public IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View(new SendMailModel
            {
                Email = "2586662969@qq.com",
                FromAlias = "night-king",
                Subject = "收到此消息说明调用成功",
                Content = "您好，欢迎使用，收到此消息说明调用成功,更多信息请访问Github：https://github.com/night-king/aliyun-net-sdk-dm-dot-net-core.",
            });
        }

        [HttpPost]
        public IActionResult Index(SendMailModel model)
        {
            var err = "";
            var ret = _emailSender.SendEmail(model.Email, model.FromAlias, model.Subject, model.Content, out err);
            ModelState.AddModelError("", err);
            return View();
        }
    }
}
