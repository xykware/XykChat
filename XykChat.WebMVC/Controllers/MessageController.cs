using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XykChat.Models.MessageModels;
using XykChat.Services;

namespace XykChat.WebMVC.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.ChannelID = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MessageCreate model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userID);
            service.SendChannelMessage(model, id);

            ViewBag.ChannelID = id;

            return RedirectToAction($"Index/{id}", "Channel", null);
        }
    }
}