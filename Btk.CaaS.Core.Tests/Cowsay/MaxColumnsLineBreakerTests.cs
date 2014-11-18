using ApprovalTests;
using ApprovalTests.Reporters;
using Btk.CaaS.Core.Cowsay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Btk.CaaS.Core.Tests.Cowsay
{
    [UseReporter(typeof(DiffReporter))]
    public class MaxColumnsLineBreakerTests
    {
        [Fact]
        public void message_shorter_than_threshold_should_not_split()
        {
            var lineBreaker = new MaxColumnsLineBreaker(5);
            var msg = "123";

            var result = lineBreaker.Break(msg);
            Assert.Equal(1, result.Count());
            Assert.Equal("123", result.First());
        }

        [Fact]
        public void message_longer_than_threshold_should_split()
        {
            var lineBreaker = new MaxColumnsLineBreaker(5);
            var msg = "12345678901";

            var result = lineBreaker.Break(msg);
            Assert.Equal(3, result.Count());
            Approvals.VerifyAll(result, "label");
        }

    }
}
