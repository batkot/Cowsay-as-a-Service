using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btk.CaaS.Controllers
{
    public interface IReleaseService
    {
        DateTime GetReleaseDate();
    }

    public class ReleaseService : IReleaseService
    {
        private DateTime _releaseDate;
        public ReleaseService(DateTime releaseDate)
        {
            _releaseDate = releaseDate;
        }

        public DateTime GetReleaseDate()
        {
            return _releaseDate;
        }
    }
}
