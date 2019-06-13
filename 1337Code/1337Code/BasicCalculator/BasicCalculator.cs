using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1337Code.BasicCalculator
{
    // https://leetcode.com/problems/basic-calculator/
    public sealed class BasicCalculator
    {
        public int Calculate(string s)
        {
            var tokens = Tokenize(s).ToList();

            return CalculatePartial(tokens);
        }

        private IEnumerable<string> Tokenize(string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                switch(c)
                {
                    case ' ':
                        if (sb.Length > 0)
                        {
                            yield return sb.ToString();
                            sb.Clear();
                        }

                        continue;
                    case '+':
                    case '-':
                    case '(':
                    case ')':
                        if (sb.Length > 0)
                        {
                            yield return sb.ToString();
                            sb.Clear();
                        }

                        yield return c.ToString();
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }

            if (sb.Length > 0)
            {
                yield return sb.ToString();
            }
        }

        private int CalculatePartial(List<string> tokens)
        {
            var numOfTokens = tokens.Count;

            var stack = new Stack<(int Result, int Sign)>();

            var result = 0;
            var sign = 1;
            for (var i = 0; i < numOfTokens; i++)
            {
                var token = tokens[i];
                switch(token)
                {
                    case "(":
                        stack.Push((result, sign));
                        result = 0;
                        sign = 1;
                        break;
                    case ")":
                        var (intermediateResult, intermediateSign) = stack.Pop();
                        result = result * intermediateSign + intermediateResult;
                        break;
                    case "+":
                        sign = 1;
                        break;
                    case "-":
                        sign = -1;
                        break;
                    default:
                        result += sign * int.Parse(token);
                        break;
                }
            }

            return result;
        }
    }
}
