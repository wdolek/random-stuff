using System;
using System.Collections.Generic;

namespace _1337Code.LongestSubstring
{
    // https://leetcode.com/problems/longest-substring-without-repeating-characters/
    public sealed class LongestSubstring
    {
        public int LengthOfLongestSubstring(string s)
        {
            var chars = new Dictionary<char, int>();

            var start = 0;
            var maxSubstring = 0;

            // NB! we need to keep track of last occurence of char, for example "abac" longest substring is "bac"
            //     -> if we don't keep track of char, we will end up with "ac" only
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (chars.ContainsKey(c))
                {
                    if (chars[c] >= start)
                    {
                        start = chars[c] + 1;
                    }
                }

                maxSubstring = Math.Max(maxSubstring, i - start + 1);
                chars[c] = i;
            }

            return maxSubstring;
        }
    }
}
