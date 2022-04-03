
using LeetCode.Interface;
using System.Text;

namespace Solutions.S0316
{
    public class Info : ILeetInfo
    {
        public string Problem => "Remove Duplicate Letters";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.String,
            TopicType.Stack,
            TopicType.Greedy,
            TopicType.MonotonicStack
        };
    }

    public class Solution : ILeet
    {
        readonly string str = "cbacdcbc";

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

            return solution.RemoveDuplicateLetters(str);
        }
    }
    public class Solution1 : ISolution
    {
        public string RemoveDuplicateLetters(string s)
        {
            bool[] visited = new bool[26];
            var stack = new Stack<char>();
            int[] freq = new int[26];
            foreach (char c in s)
            {
                freq[c - 'a'] += 1;
            }

            foreach (char c in s)
            {
                if (visited[c - 'a'])
                {
                    freq[c - 'a'] -= 1;
                    continue;
                }
                while (stack.Count != 0 && stack.Peek() > c && freq[stack.Peek() - 'a'] > 0)
                {
                    visited[stack.Peek() - 'a'] = false;
                    stack.Pop();
                }
                stack.Push(c);
                visited[c - 'a'] = true;
                freq[c - 'a'] -= 1;
            }
            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb = sb.Insert(0, stack.Pop());
            }
            return sb.ToString();
        }
    }

    internal interface ISolution
    {
        string RemoveDuplicateLetters(string s);
    }
}
