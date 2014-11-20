using Btk.CaaS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Btk.CaaS.Controllers.Api
{
    public class FortuneController : ApiController
    {
        private IFortuneProvider _fortuneProvider;
        public FortuneController(IFortuneProvider fortuneProvider)
        {
            if (fortuneProvider == null)
                throw new ArgumentNullException("fortuneProvider");

            _fortuneProvider = fortuneProvider;
        }

        public IHttpActionResult Get()
        {
            try
            {
                var result = _fortuneProvider.GetFortune().Replace("\r\n", "<br>");
                return Ok(result);
            }
            catch(FortuneServiceUnavailableException ex)
            {
                return NotFound(); 
            }
        }

    }
}
