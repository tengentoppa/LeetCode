
using LeetCode.Interface;

namespace Solutions.S763
{
    public class Solution : ILeet
    {
        readonly string str = "ababcbacadefegdehijhklij";

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
            ISolution solution = new Solution2();

            return solution.PartitionLabels(str);
        }
    }
    public class Solution1 : ISolution
    {
        public IList<int> PartitionLabels(string s)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                dict[s[i]] = i;
            }
            var result = new List<int>();
            var start = 0;
            var end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                end = Math.Max(end, dict[s[i]]);
                if (i == end)
                {
                    result.Add(end - start + 1);
                    start = end + 1;
                }
            }
            return result;
        }
    }
    public class Solution2 : ISolution
    {
        public IList<int> PartitionLabels(string s)
        {
            var dict = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                dict[s[i] - 'a'] = i;
            }
            var result = new List<int>();
            var start = 0;
            var end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                end = Math.Max(end, dict[s[i] - 'a']);
                if (i == end)
                {
                    result.Add(end - start + 1);
                    start = end + 1;
                }
            }
            return result;
        }
    }

    public interface ISolution
    {
        IList<int> PartitionLabels(string s);
    }
}
