using ApprovalTests;
using ApprovalTests.Reporters;
using Btk.CaaS.Core.Cowsay;
using Btk.CaaS.Core.Cowsay.Avatars;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Btk.CaaS.Core.Tests.Cowsay
{
    [UseReporter(typeof(DiffReporter))]
    public class CowTests
    {
        [Fact]
        public void renders_text_and_avatar_properly()
        {
            var textProvider = A.Fake<ILineBreaker>();
            var message = "this message doesn't matter";
            A.CallTo(() => textProvider.Break(message)).WithAnyArguments().Returns(new[] { "Hello, hello, hello", "I'm a cow. You're not.", "\t~Somebody" });

            var cow = new Cow(textProvider, new CowAvatar());

            var result = cow.Say(message);

            Approvals.Verify(result);
        }
    }
}
