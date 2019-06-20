using System;
using System.Collections.Generic;
using System.Linq;

namespace _1337Code.LetterCombinations
{
    // https://leetcode.com/problems/letter-combinations-of-a-phone-number/
    public sealed class LetterCombinator
    {
        private static Dictionary<char, char[]> _digitCharMap = new Dictionary<char, char[]>
        {
            ['1'] = new[] { '1' },
            ['2'] = new[] { 'a', 'b', 'c' },
            ['3'] = new[] { 'd', 'e', 'f' },
            ['4'] = new[] { 'g', 'h', 'i' },
            ['5'] = new[] { 'j', 'k', 'l' },
            ['6'] = new[] { 'm', 'n', 'o' },
            ['7'] = new[] { 'p', 'q', 'r', 's' },
            ['8'] = new[] { 't', 'u', 'v' },
            ['9'] = new[] { 'w', 'x', 'y', 'z' },
            ['0'] = new[] { '0' },
        };

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>(0);
            }

            // collect all substitutions
            var substs = new char[digits.Length][];
            for (var i = 0; i < digits.Length; i++)
            {
                var digit = digits[i];
                if (!_digitCharMap.TryGetValue(digit, out var subst))
                {
                    throw new ArgumentNullException();
                }

                substs[i] = subst;
            }

            return BuildCombination(string.Empty, new Span<char[]>(substs)).ToList();
        }

        // answer: https://leetcode.com/problems/letter-combinations-of-a-phone-number/discuss/298351/C-solution-in-one-line
        public IList<string> LetterCombinationsUsingLinq(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>(0);
            }

            return Enumerable
                .Range(1, digits.Length - 1)
                .Aggregate(
                    // seed: combinations for first digit
                    _digitCharMap[digits[0]]
                        .Select(c => c.ToString())
                        .ToList(),
                    // accumulator func: all combinations so far
                    (current, i) =>
                        current
                            .SelectMany(
                                combination => _digitCharMap[digits[i]],
                                (combination, character) => combination + character)
                            .ToList());
        }

        private IEnumerable<string> BuildCombination(string current, Span<char[]> substs)
        {
            // base case: no more combinations possible
            if (substs.Length == 0)
            {
                return new[] { current };
            }

            // take only next digit substitutions
            var subst = substs[0];

            // recursively collect results of combined substitutions
            var result = new List<string>(subst.Length);
            foreach (var c in subst)
            {
                result.AddRange(BuildCombination(current + c, substs.Slice(1)));
            }

            return result;
        }
    }
}
