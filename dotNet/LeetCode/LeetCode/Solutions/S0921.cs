
using LeetCode.Interface;

namespace Solutions.S0921
{
    public class Info : ILeetInfo
    {
        public string Problem => "Minimum Add to Make Parentheses Valid";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.String,
            TopicType.Stack,
            TopicType.Greedy
        };
    }

    public class Solution : ILeet
    {
        readonly string s = "(())()(()()((()()()))((((";

        public object Input
        {
            get => new
            {
                s
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.MinAddToMakeValid(s);
        }
    }
    public class Solution1 : ISolution
    {
        public int MinAddToMakeValid(string s)
        {
            var left = 0;
            var invalid = 0;
            foreach (var c in s)
            {
                if (c == '(') left++;
                else if (c == ')' && left > 0) left--;
                else invalid++;
            }

            return invalid + left;
        }
    }

    internal interface ISolution
    {
        int MinAddToMakeValid(string s);
    }
}
