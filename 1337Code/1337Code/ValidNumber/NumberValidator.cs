using System.Text.RegularExpressions;

namespace _1337Code.ValidNumber
{
    // https://leetcode.com/problems/valid-number/
    public sealed class NumberValidator
    {
        private static readonly Regex DecimalExpression =
            new Regex(
                @"^\s*([+-]?(\d+|\d+\.\d+|\d+\.|\.\d+)(e[+-]?\d+)?)\s*$",
                RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public bool IsNumber(string s)
        {
            return DecimalExpression.IsMatch(s.Trim());
        }

        public bool IsNumberPlain(string s)
        {
            s = s.Trim();

            var strLength = s.Length;

            var hasExponent = false;
            var hasDecimalPoint = false;
            var hasSign = false;

            var digits = 0;
            var c = ' ';

            for (int i = 0; i < strLength; i++)
            {
                c = s[i];

                switch (c)
                {
                    case '+':
                    case '-':
                        if (hasSign || (!hasExponent && i != 0))
                        {
                            return false;
                        }

                        hasSign = true;
                        break;

                    case 'e':
                        if (i == 0 || hasSign || (digits == 0 && hasDecimalPoint) || hasExponent)
                        {
                            return false;
                        }

                        hasExponent = true;
                        break;

                    case '.':
                        if (hasDecimalPoint || hasExponent)
                        {
                            return false;
                        }

                        hasDecimalPoint = true;
                        break;

                    default:
                        if (c < '0' || c > '9')
                        {
                            return false;
                        }

                        hasSign = hasExponent & hasSign;
                        digits++;
                        break;
                }
            }

            return strLength != 0
                && c != 'e'
                && c != '+'
                && c != '-'
                && (c != '.' || digits != 0);
        }
    }
}
