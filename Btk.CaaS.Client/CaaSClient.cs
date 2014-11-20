using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Client
{
    public class CaaSClient : ClientBase<ICaaSService>, ICaaSService
    {
        public string Cowsay(string message)
        {
            return base.Channel.Cowsay(message);
        }
    }
}
