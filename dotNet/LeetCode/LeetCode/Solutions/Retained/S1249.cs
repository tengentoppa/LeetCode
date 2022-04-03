
using LeetCode.Interface;
using System.Text;

namespace Solutions.S1249
{
    public class Info : ILeetInfo
    {
        public string Problem => "Minimum Remove to Make Valid Parentheses";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.String,
            TopicType.Stack
        };
    }

    public class Solution : ILeet
    {
        readonly string str = "))(((123)432)";

        public object Input
        {
            get => new
            {
                str,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.MinRemoveToMakeValid("))(((123)432)");
        }
    }
    public class Solution1 : ISolution
    {
        public string MinRemoveToMakeValid(string s)
        {
            var stack = new Stack<KeyValuePair<int, char>>();
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == ')')
                {
                    if (stack.Any() && stack.Peek().Value == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(new KeyValuePair<int, char>(i, ')'));
                    }
                }
                else if (c == '(')
                {
                    stack.Push(new KeyValuePair<int, char>(i, '('));
                }
            }

            var result = new StringBuilder(s);
            foreach (var stc in stack)
            {
                result.Remove(stc.Key, 1);
            }
            return result.ToString();
        }
    }

    public interface ISolution
    {
        string MinRemoveToMakeValid(string s);
    }
}
