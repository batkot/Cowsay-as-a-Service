using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Core.Cowsay
{
    public class MaxColumnsLineBreaker : ILineBreaker
    {
        private int _charsPerRow;
        public MaxColumnsLineBreaker(int charsPerRow)
        {
            if (charsPerRow < 1)
                throw new ArgumentOutOfRangeException("charsPerRow", "charsPerRow has to be positive number");

            _charsPerRow = charsPerRow;
        }

        public IEnumerable<string> Break(string message)
        {
            for (int i = 0; i < message.Length; i += _charsPerRow)
                yield return message.Substring(i, Math.Min(_charsPerRow, message.Length - i));
        }
    }
}
