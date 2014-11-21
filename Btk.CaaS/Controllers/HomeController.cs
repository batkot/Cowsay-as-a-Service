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
        private DateTime _releaseDate = new DateTime(2014, 11, 21, 21, 40, 0);
        public ActionResult Index()
        {
            if(DateTime.UtcNow < _releaseDate)
                return RedirectToAction("ComingSoon");

            return View();
        }

        public ActionResult ComingSoon()
        {
            TimeSpan remaining = _releaseDate - DateTime.UtcNow;
            return View(new CountdownModel { RemainingSeconds = Math.Max((int)remaining.TotalSeconds, 0) });
        }

        public ActionResult Check()
        {
            return PartialView();
        }
    }
}