using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Core.Cowsay
{
    public interface IAvatarDrawer
    {
        string Draw(int rowLength);
    }
}
