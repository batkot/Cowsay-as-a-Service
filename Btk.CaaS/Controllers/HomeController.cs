using Btk.CaaS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Btk.CaaS.Controllers
{
    public class HomeController : Controller
    {
        private DateTime _releaseDate = new DateTime(2014, 11, 22, 23, 0, 0);
        public ActionResult Index()
        {
            return RedirectToActionPermanent("ComingSoon");
            //return View();
        }

        public ActionResult ComingSoon()
        {
            TimeSpan remaining = _releaseDate - DateTime.UtcNow;
            return View(new CountdownModel { RemainingSeconds = (int)remaining.TotalSeconds });
        }
    }
}