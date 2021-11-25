using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XykChat.Models.MemberModels;
using XykChat.Services;

namespace XykChat.WebMVC.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userID);

            service.Create(model);

            return RedirectToAction("Index");
        }
    }
}