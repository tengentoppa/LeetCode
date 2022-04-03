
using LeetCode.Interface;

namespace Solutions.S0344
{
    public class Info : ILeetInfo
    {
        public string Problem => "Reverse String";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.TwoPointers,
            TopicType.String,
            TopicType.Recursion
        };
    }
    public class Solution : ILeet
    {
        readonly char[] s = new char[] { '1' };

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
            solution.ReverseString(s);
            return s;
        }
    }
    public class Solution1 : ISolution
    {
        public void ReverseString(char[] s)
        {
            var right = s.Length - 1;
            var left = 0;
            while (left < right)
            {
                char tmp = s[left];
                s[left++] = s[right];
                s[right--] = tmp;
            }
        }
    }

    internal interface ISolution
    {
        void ReverseString(char[] s);
    }
}
