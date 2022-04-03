
using LeetCode.Interface;

namespace Solutions.S0003
{
    public class Info : ILeetInfo
    {
        public string Problem => "Longest Substring Without Repeating Characters";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.HashTable,
            TopicType.String,
            TopicType.SlidingWindow
        };
    }

    public class Solution : ILeet
    {
        readonly string s = "abcabcbb";

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

            return solution.LengthOfLongestSubstring(s);
        }
    }
    public class Solution1 : ISolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var ans = 0;
            var dic = new Dictionary<char, int>();
            for (int i = 0, j = 0; j < s.Length; j++)
            {
                if (dic.ContainsKey(s[j]))
                {
                    i = Math.Max(dic[s[j]], i);
                }

                ans = Math.Max(ans, j - i + 1);
                dic[s[j]] = j + 1;
            }

            return ans;
        }
    }

    internal interface ISolution
    {
        int LengthOfLongestSubstring(string s);
    }
}
