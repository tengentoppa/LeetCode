
using LeetCode.Interface;

namespace Solutions.S0680
{
    public class Info : ILeetInfo
    {
        public string Problem => "Valid Palindrome II";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.TwoPointers,
            TopicType.String,
            TopicType.Greedy
        };
    }
    public class Solution : ILeet
    {
        readonly string s = "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga";

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

            return solution.ValidPalindrome(s);
        }
    }
    public class Solution1 : ISolution
    {
        public bool ValidPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return CheckPalindrome(s, left + 1, right) || CheckPalindrome(s, left, right - 1);
                }
                left++;
                right--;
            }
            return true;
        }
        private bool CheckPalindrome(string s, int i, int j)
        {
            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }

                i++;
                j--;
            }

            return true;
        }
    }

    internal interface ISolution
    {
        bool ValidPalindrome(string s);
    }
}
