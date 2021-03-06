﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Btk.CaaS.Controllers;
using Xunit;
using FakeItEasy;
using Btk.CaaS.Core.Cowsay;
using Btk.CaaS.Core;

namespace Btk.CaaS.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void index_after_release_date_should_return_site()
        {
            var cow = A.Fake<Cow>();
            var fortune = A.Fake<IFortuneProvider>();
            var releaseDate = A.Fake<IReleaseService>();
            
            A.CallTo(() => cow.Say(null)).WithAnyArguments().Returns("Heey");
            A.CallTo(() => fortune.GetFortune()).Returns("AA");
            A.CallTo(() => releaseDate.GetReleaseDate()).Returns(DateTime.UtcNow.AddHours(-1));

            HomeController controller = new HomeController(cow, fortune, releaseDate);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_before_release_date_should_redirect()
        {
            var cow = A.Fake<Cow>();
            var fortune = A.Fake<IFortuneProvider>();
            var releaseDate = A.Fake<IReleaseService>();
            
            A.CallTo(() => cow.Say(null)).WithAnyArguments().Returns("Heey");
            A.CallTo(() => fortune.GetFortune()).Returns("AA");
            A.CallTo(() => releaseDate.GetReleaseDate()).Returns(DateTime.UtcNow.AddHours(1));

            HomeController controller = new HomeController(cow, fortune, releaseDate); 

            // Act
            RedirectToRouteResult result = controller.Index() as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
