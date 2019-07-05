using System;
using System.Collections.Generic;
using System.Linq;

namespace _1337Code.GroupAnagrams
{
    // https://leetcode.com/problems/group-anagrams/
    public sealed class AnagramGroupator
    {
        public IList<IList<string>> GroupAnagrams(string[] strs) =>
            strs.GroupBy(s => s, AnagramComparator.Instance)
                .Select(g => (IList<string>)g.ToList())
                .ToList();

        public IList<IList<string>> GroupAnagramsWithoutComparer(string[] strs)
        {
            var d = new Dictionary<int, IList<string>>();

            foreach (var s in strs)
            {
                var hashCode = new string(s.OrderBy(c => c).ToArray()).GetHashCode();
                if (d.ContainsKey(hashCode))
                {
                    d[hashCode].Add(s);
                } else
                {
                    d.Add(hashCode, new List<string> { s });
                }
            }

            return d.Values.ToList();
        }

        // `GroupBy` first calls `GetHashCode`
        // - if values have same hash code, `Equals` is called to check actual equality
        private class AnagramComparator : IEqualityComparer<string>
        {
            public static readonly AnagramComparator Instance = new AnagramComparator();

            public bool Equals(string x, string y)
            {
                // ----------------------------
                // taken from `../ValidAnagram`
                // ----------------------------

                if (x.Length != y.Length)
                {
                    return false;
                }

                // init array 0..25 to represent each char count
                Span<int> charCount = stackalloc int['z' - 'a' + 1];

                // +1 for source
                foreach (var c in x)
                {
                    charCount[c - 'a']++;
                }

                // -1 for target
                foreach (var c in y)
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

            public int GetHashCode(string obj) =>
                obj.OrderBy(c => c)
                    .Select(c => (int)c)
                    .Aggregate(17, (c, a) => (c * 23) + a);
        }
    }
}
