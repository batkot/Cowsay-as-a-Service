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
    public class WordWrappingLineBreakerTests
    {
        private int _charsInRow;

        public WordWrappingLineBreakerTests()
        {
            _charsInRow = 50;
        }

        [Fact]
        public void message_shorter_than_threshold_should_not_break()
        {
            var breaker = new WordWrappingLineBreaker(_charsInRow);
            var message = "ABCDEF";

            var result = breaker.Break(message);
            Assert.Equal(1, result.Count());
            Assert.Equal("ABCDEF", result.First());
        }

        [Fact]
        public void message_length_is_multiplicity_of_chars_in_row_should_break_properly()
        {
            var breaker = new WordWrappingLineBreaker(_charsInRow);
            var message = string.Join(" ", new string('A',50), new string('A', 50));

            var result = breaker.Break(message);
            Assert.Equal(2, result.Count());
            Approvals.VerifyAll(result, "rows");
        }

        [Fact]
        public void words_that_dont_fit_in_one_line_should_break_into_separate_lines()
        {
            var breaker = new WordWrappingLineBreaker(_charsInRow);
            var message = string.Join(string.Empty, Enumerable.Range(0, 103).Select(x => x % 27 == 0 ? " " : "A"));

            var result = breaker.Break(message);
            Assert.Equal(3, result.Count());
            Approvals.VerifyAll(result, "rows");
        }

        [Fact]
        public void hipster_ipsum_breaked_nicely()
        {
            var breaker = new WordWrappingLineBreaker(_charsInRow);
            var message = @"Neutra +1 YOLO, sustainable bitters typewriter Marfa yr synth. Church-key letterpress freegan literally authentic Vice, roof party mustache whatever. Tofu raw denim street art twee plaid McSweeney's, skateboard Bushwick Austin drinking vinegar brunch cold-pressed locavore jean shorts artisan. Meditation fashion axe hella flannel normcore. Neutra 90's Marfa, heirloom polaroid chambray narwhal umami +1 viral biodiesel pork belly kogi DIY gentrify. Bespoke listicle Portland forage. Helvetica keytar chia Banksy, skateboard jean shorts Portland put a bird on it banh mi shabby chic Bushwick.";

            var result = breaker.Break(message);
            Assert.Equal(false, result.Any(s => s.Length > _charsInRow));
            Approvals.VerifyAll(result, "rows");
        }
    }
}
