using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Core.Cowsay.Avatars
{
    public class CowAvatar : IAvatarDrawer
    {
        public string Draw(int rowLength)
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"        \   ^__^");
            builder.AppendLine(@"         \  (oo)\_______");
            builder.AppendLine(@"            (__)\       )\/\");
            builder.AppendLine(@"               ||----w |");
            builder.AppendLine(@"               ||     ||");
            return builder.ToString();
        }
    }
}
