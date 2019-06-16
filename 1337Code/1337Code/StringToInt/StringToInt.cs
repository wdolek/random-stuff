using System;

namespace _1337Code.StringToInt
{
    // https://leetcode.com/problems/string-to-integer-atoi/
    public sealed class StringToInt
    {
        public int MyAtoi(string str)
        {
            var signRead = false;
            var sign = 1;

            var digitRead = false;

            var value = 0L;
            try
            {
                for (var i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        // we got space while already having sign or/and digit -> break
                        if (signRead || digitRead)
                        {
                            break;
                        }

                        continue;
                    }

                    if (str[i] == '-' || str[i] == '+')
                    {
                        // we got another sign or already read digit -> break
                        if (signRead || digitRead)
                        {
                            break;
                        }

                        sign = str[i] == '-' ? -1 : 1;
                        signRead = true;

                        continue;
                    }

                    if (str[i] < '0' || str[i] > '9')
                    {
                        break;
                    }

                    digitRead = true;
                    checked
                    {
                        value = (value * 10) + (str[i] - '0');
                    }
                }
            }
            catch (OverflowException)
            {
                return sign > 0
                    ? int.MaxValue
                    : int.MinValue;
            }

            value *= sign;

            return (int)Math.Max(
                int.MinValue,
                Math.Min(
                    int.MaxValue,
                    value));
        }
    }
}
