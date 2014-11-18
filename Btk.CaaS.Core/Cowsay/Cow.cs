using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Core.Cowsay
{
    public class Cow
    {
        private ILineBreaker _lineBreaker;
        public Cow(ILineBreaker lineBreaker)
        {
            _lineBreaker = lineBreaker;
        }

        public string Say(string message)
        {
            var builder = new StringBuilder();

            foreach(var line in _lineBreaker.Break(message))
            {
                builder.AppendLine(line);
            }

            return builder.ToString();
        }
    }
}
