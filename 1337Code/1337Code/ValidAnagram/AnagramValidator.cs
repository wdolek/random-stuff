using System;
using System.Linq;

namespace _1337Code.ValidAnagram
{
    // https://leetcode.com/problems/valid-anagram/
    public sealed class AnagramValidator
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            // create dictionary char -> num of occurrences
            var sourceCharCount = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            var targetCharCount = t.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            // check we have same number of chars and same count of each char in both dictionaries
            // (NB! checking size of dictionaries is not the same as checking string lengths at the beginning)
            return sourceCharCount.Count == targetCharCount.Count
                && sourceCharCount.All(vp => targetCharCount.ContainsKey(vp.Key) && targetCharCount[vp.Key] == vp.Value);
        }

        public bool IsAnagramWithoutLinq(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            // init array 0..25 to represent each char count
            Span<int> charCount = stackalloc int['z' - 'a' + 1];

            // +1 for source
            foreach (var c in s)
            {
                charCount[c - 'a']++;
            }

            // -1 for target
            foreach (var c in t)
            {
                charCount[c - 'a']--;
            }

            // we expect all 0
            foreach (var i in charCount)
            {
                if (i != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
