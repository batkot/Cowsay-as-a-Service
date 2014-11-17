using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Core
{
    public class TcpFortuneProvider : IFortuneProvider
    {
        private readonly string _serverHost;
        private readonly int _port;

        public TcpFortuneProvider(string host, int port)
        {
            _serverHost = host;
            _port = port;
        }

        public string GetFortune()
        {
            string fortune = string.Empty;

            using (var client = new TcpClient(_serverHost, _port))
                using (var stream = client.GetStream())
                    using (var reader = new StreamReader(stream))
                        fortune = reader.ReadToEnd();

            return fortune;
        }
    }
}
