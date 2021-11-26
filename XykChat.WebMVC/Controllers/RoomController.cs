using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XykChat.Models.ChannelModels;
using XykChat.Models.RoomModels;
using XykChat.Services;

namespace XykChat.WebMVC.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RoomService(userID);
            var model = service.GetRooms();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RoomService(userID);

            service.Create(model);

            return RedirectToAction("Index");
        }

        public ActionResult View(int id)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RoomService(userID);
            var model = service.GetRoomChannels(id);

            return View(model);
        }

        public ActionResult Join()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Join(RoomJoin model, int id)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RoomService(userID);
            service.JoinRoom(model, id);

            return RedirectToAction($"View/{id}");
        }

        public ActionResult AddChannel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddChannel(ChannelCreate model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new RoomService(userID);
            service.AddRoomChannel(model, id);

            return RedirectToAction($"View/{id}");
        }
    }
}