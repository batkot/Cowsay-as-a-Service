using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Btk.CaaS.Core.Cowsay
{
    public interface ILineBreaker
    {
        IEnumerable<string> Break(string message);
    }
}
