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
        private IAvatarDrawer _avatarDrawer;
        public Cow(ILineBreaker lineBreaker, IAvatarDrawer avatarDrawer)
        {
            _lineBreaker = lineBreaker;
            _avatarDrawer = avatarDrawer;
        }

        public string Say(string message)
        {
            var builder = new StringBuilder();

            foreach(var line in _lineBreaker.Break(message))
            {
                builder.AppendLine(line);
            }

            builder.AppendLine(_avatarDrawer.Draw(10));
            return builder.ToString();
        }
    }
}
