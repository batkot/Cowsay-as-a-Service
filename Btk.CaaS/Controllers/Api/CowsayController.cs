using Btk.CaaS.Core;
using Btk.CaaS.Core.Cowsay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Btk.CaaS.Controllers.Api
{
    [RoutePrefix("api/cowsay")]
    public class CowsayController : ApiController
    {
        private Cow _cow;
        private IFortuneProvider _fortuneProvider;
        public CowsayController(Cow cow, IFortuneProvider fortuneProvider)
        {
            _cow = cow;
            _fortuneProvider = fortuneProvider;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Say([FromBody] string message)
        {
            message = string.IsNullOrEmpty(message) ? _fortuneProvider.GetFortune() : message;
            return Ok(_cow.Say(message));
        }
    }
}
