
using LeetCode.Interface;

namespace Solutions.S0020
{
    public class Info : ILeetInfo
    {
        public string Problem => "Valid Parentheses";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.String,
            TopicType.Stack
        };
    }

    public class Solution : ILeet
    {
        readonly string s = "(([))[]{}";

        public object Input
        {
            get => new
            {
                s,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.IsValid(s);
        }
    }
    public class Solution1 : ISolution
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    if (!stack.TryPop(out var p)) return false;
                    if (c == '}' && p != '{') return false;
                    if (c == ']' && p != '[') return false;
                    if (c == ')' && p != '(') return false;
                }
            }
            if (stack.Count > 0) return false;
            return true;
        }
    }

    internal interface ISolution
    {
        bool IsValid(string s);
    }
}
