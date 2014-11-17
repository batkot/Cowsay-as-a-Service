using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Btk.CaaS.Core.Tests
{
    public class TcpFortuneProviderTests
    {
        private string _host;
        private int _port;

        public TcpFortuneProviderTests()
        {
            _host = "djxmmx.net";
            _port = 17;
        }
        
        [Fact]
        public void tcp_server_should_return_fortune()
        {
            var fortuneProvider = new TcpFortuneProvider(_host, _port);

            string fortune = fortuneProvider.GetFortune();

            Assert.NotNull(fortune);
        }
    }
}
