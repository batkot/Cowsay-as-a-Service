using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Btk.CaaS.Core.Cowsay
{
    public class WordWrappingLineBreaker : ILineBreaker
    {
        private int _charsPerRow;
        public WordWrappingLineBreaker(int charsPerRow)
        {
            if (charsPerRow < 1)
                throw new ArgumentOutOfRangeException("charsPerRow", "charsPerRow has to be positive number");

            _charsPerRow = charsPerRow;
        }

        public IEnumerable<string> Break(string message)
        {
            var builder = new StringBuilder();
            int charsLeftInRow = _charsPerRow;

            foreach(var word in message.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (charsLeftInRow <= word.Length && charsLeftInRow != _charsPerRow)
                {
                    yield return builder.ToString();
                    charsLeftInRow = _charsPerRow;
                    builder.Clear();
                }
                else if (charsLeftInRow != _charsPerRow)
                {
                    builder.Append(" ");
                    charsLeftInRow--;
                }

                builder.Append(word);
                charsLeftInRow -= word.Length;
            }

            if (builder.Length > 0)
                yield return builder.ToString();
        }
    }
}
