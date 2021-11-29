using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XykChat.Services;

namespace XykChat.WebMVC.Controllers
{
    public class ChannelController : Controller
    {
        public ActionResult Index(int id)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ChannelService(userID);
            var model = service.GetChannelMessages(id);

            ViewBag.ChannelID = id;

            return View(model);
        }
    }
}