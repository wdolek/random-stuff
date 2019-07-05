using System;
using System.Linq;
using System.Text;

namespace _1337Code.ReverseWords
{
    // https://leetcode.com/problems/reverse-words-in-a-string/
    public sealed class WordReverter
    {
        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }

            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // allocate string builder with appropriate capacity (sum of lengths + spaces)
            // (e.g. "foo bar baz" = 11 = 9 chars + 3 words - 1 (one space less than words))
            var sb = new StringBuilder(words.Sum(w => w.Length) + words.Length - 1);

            // append words in reverted order
            for (var i = words.Length - 1; i >= 0; i--)
            {
                sb.Append(words[i]);
                if (i > 0)
                {
                    sb.Append(' ');
                }
            }

            return sb.ToString();
        }
    }
}
