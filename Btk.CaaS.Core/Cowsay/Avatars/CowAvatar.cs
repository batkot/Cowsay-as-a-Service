using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Core.Cowsay.Avatars
{
    public class CowAvatar : IAvatarDrawer
    {
        private int _avatarLength = 20;
        public string Draw(int rowLength)
        {
            int center = (rowLength - _avatarLength)/2;
            string offset = new string(' ', center);
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("{0}{1}", offset, @"\   ^__^"));
            builder.AppendLine(string.Format("{0}{1}", offset, @" \  (oo)\_______"));
            builder.AppendLine(string.Format("{0}{1}", offset, @"    (__)\       )\/\"));
            builder.AppendLine(string.Format("{0}{1}", offset, @"       ||----w |"));
            builder.AppendLine(string.Format("{0}{1}", offset, @"       ||     ||"));
            return builder.ToString();
        }
    }
}
