
using LeetCode.Interface;
using System.Text;

namespace Solutions.S0394
{
    public class Info : ILeetInfo
    {
        public string Problem => "Decode String";

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.String,
            TopicType.Stack,
            TopicType.Recursion
        };
    }
    public class Solution : ILeet
    {
        readonly string s = "afsda5[rj3[k]]laa";

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

            return solution.DecodeString(s);
        }
    }
    public class Solution3 : ISolution
    {
        public string DecodeString(string s)
        {
            var result = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i])) result.Append(GetRepeatedStr(s, ref i));
                else result.Append(s[i]);
            }

            return result.ToString();
        }

        private string GetRepeatedStr(string s, ref int index)
        {
            var countStr = "";
            while (s[index] != '[')
            {
                countStr += s[index++];
            }
            var count = int.Parse(countStr);
            index++; // skip char '['

            var repeatStr = "";
            while (s[index] != ']')
            {
                if (char.IsDigit(s[index])) repeatStr += GetRepeatedStr(s, ref index);
                else repeatStr += s[index];
                index++;
            }

            var result = new StringBuilder(repeatStr.Length * count);
            while (count-- > 0)
            {
                result.Append(repeatStr);
            }

            return result.ToString();
        }
    }

    public class Solution1 : ISolution
    {
        public string DecodeString(string s)
        {
            var result = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i])) result += GetRepeatedStr(s, ref i);
                else result += s[i];
            }

            return result.ToString();
        }

        private string GetRepeatedStr(string s, ref int index)
        {
            var countStr = "";
            while (s[index] != '[')
            {
                countStr += s[index++];
            }
            var count = int.Parse(countStr);
            index++; // skip char '['

            var repeatStr = "";
            while (s[index] != ']')
            {
                if (char.IsDigit(s[index])) repeatStr += GetRepeatedStr(s, ref index);
                else repeatStr += s[index];
                index++;
            }

            var result = "";
            while (count-- > 0)
            {
                result += repeatStr;
            }

            return result;
        }
    }

    public class Solution2 : ISolution
    {
        int index = 0;
        public string DecodeString(string s)
        {
            var result = new StringBuilder();
            while (index < s.Length && s[index] != ']')
            {
                if (!char.IsDigit(s[index]))
                {
                    result.Append(s[index++]);
                }
                else
                {
                    int k = 0;
                    while (char.IsDigit(s[index]))
                    {
                        k = k * 10 + (s[index++] - '0');
                    }
                    index++;
                    var decodedStr = DecodeString(s);
                    index++;
                    while (k-- > 0)
                    {
                        result.Append(decodedStr);
                    }
                }
            }
            return result.ToString();
        }
    }

    internal interface ISolution
    {
        string DecodeString(string s);
    }
}
