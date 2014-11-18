using Btk.CaaS.Core.Fortune;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Btk.CaaS.Core.Tests.Fortune
{
    public class TcpFortuneProviderTests
    {
        private string _host;
        private int _port;
        private string _badHost;

        public TcpFortuneProviderTests()
        {
            _host = "djxmmx.net";
            _badHost = "ihopesuchuridoesntexist";
            _port = 17;
        }
        
        [Fact]
        public void tcp_server_should_return_fortune()
        {
            var fortuneProvider = new TcpFortuneProvider(_host, _port);

            string fortune = fortuneProvider.GetFortune();

            Assert.NotNull(fortune);
        }

        [Fact]
        public void tcp_server_should_throw_exception_when_unavailable()
        {
            var fortuneProvider = new TcpFortuneProvider(_badHost, _port);

            Assert.Throws<FortuneServiceUnavailableException>(() => fortuneProvider.GetFortune());
        }
    }
}
