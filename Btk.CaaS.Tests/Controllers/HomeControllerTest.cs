using System;
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
        public void Index()
        {
            var cow = A.Fake<Cow>();
            var fortune = A.Fake<IFortuneProvider>();
            
            A.CallTo(() => cow.Say(null)).WithAnyArguments().Returns("Heey");
            A.CallTo(() => fortune.GetFortune()).Returns("AA");

            // Arrange
            HomeController controller = new HomeController(cow,fortune);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
