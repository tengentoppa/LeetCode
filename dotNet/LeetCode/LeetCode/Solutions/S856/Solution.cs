
using LeetCode.Interface;

namespace Solutions.S856
{
    public class Solution : ILeet
    {
        readonly string str = "(((())()))";

        public object Input
        {
            get => new
            {
                str
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.ScoreOfParentheses(str);
        }
    }
    public class Solution1 : ISolution
    {
        public int ScoreOfParentheses(string s)
        {
            var bal = 0;
            var ans = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    bal++;
                }
                else
                {
                    bal--;
                    if (s[i - 1] == '(')
                    {
                        ans += 1 << bal;
                    }
                }
            }
            return ans;
        }
    }

    internal interface ISolution
    {
        int ScoreOfParentheses(string s);
    }
}
