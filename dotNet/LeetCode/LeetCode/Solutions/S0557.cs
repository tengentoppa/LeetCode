
using LeetCode.Interface;
using System.Text;

namespace Solutions.S0557
{
    public class Info : ILeetInfo
    {
        public string Problem => "Reverse Words in a String III";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.TwoPointers,
            TopicType.String
        };
    }

    public class Solution : ILeet
    {
        readonly string str = "Let's take LeetCode contest";

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

            return solution.ReverseWords(str);
        }
    }
    public class Solution1 : ISolution
    {
        public string ReverseWords(string s)
        {
            string[] Reverse = s.Split(' ');
            char[] temp;
            char tempChar;
            for (int i = 0; i < Reverse.Length; i++)
            {
                temp = Reverse[i].ToCharArray();
                int left = 0, right = temp.Length - 1;
                while (left < right)
                {
                    tempChar = temp[right];
                    temp[right] = temp[left];
                    temp[left] = tempChar;
                    left++; right--;
                }
                Reverse[i] = new string(temp);
            }

            return string.Join(" ", Reverse);
        }
    }
    public class Solution2 : ISolution
    {
        public string ReverseWords(string s)
        {
            return string.Join(' ', s.Split(' ').Select(d => string.Concat(d.Reverse())));
        }
    }
    public class Solution3 : ISolution
    {
        public string ReverseWords(string s)
        {
            var result = new StringBuilder();
            var lastWhite = -1;

            var i = 0;
            for (; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    var j = i - 1;
                    while (j > lastWhite)
                    {
                        result.Append(s[j--]);
                    }
                    result.Append(' ');
                    lastWhite = i;
                }
            }

            var t = i - 1;
            while (t > lastWhite)
            {
                result.Append(s[t--]);
            }

            return result.ToString();
        }
    }

    internal interface ISolution
    {
        string ReverseWords(string s);
    }
}
