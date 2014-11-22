using Btk.CaaS.Core;
using Btk.CaaS.Core.Cowsay;
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
        private Cow _cow;
        private IFortuneProvider _fortuneProvider;
        public HomeController(Cow cow, IFortuneProvider fortuneProvider, DateTime? releaseDate = null)
        {
            _cow = cow;
            _fortuneProvider = fortuneProvider;

            if (releaseDate.HasValue)
            {
                _releaseDate = releaseDate.Value;
            }
        }

        public ActionResult Index()
        {
            if(DateTime.UtcNow < _releaseDate)
                return RedirectToAction("ComingSoon");

            string message = string.Empty;
            try
            {
                message = _fortuneProvider.GetFortune();
            }
            catch(FortuneServiceUnavailableException ex)
            {
                message = "We've got some problems with Quote of the Day server";
            }
            
            ViewBag.Cowsay = _cow.Say(message);

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