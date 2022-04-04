
using LeetCode.Interface;

namespace Solutions.S0227
{
    public class Info : ILeetInfo
    {
        public string Problem => "Squares of a Sorted Array";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.TwoPointers,
            TopicType.Sorting
        };
    }

    public class Solution : ILeet
    {
        readonly string s = "1-1+1";

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

            return solution.Calculate(s);
        }
    }
    public class Solution1 : ISolution
    {
        public int Calculate(string s)
        {
            var signs = new Stack<char>();
            var digits = new Stack<int>();
            if (s == "0") return 0;
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == ' ')
                {
                    continue;
                }
                var isDigit = false;
                var digit = 0;
                while (i < s.Length && char.IsDigit(s[i]))
                {
                    isDigit = true;
                    digit = digit * 10 + (s[i++] - '0');
                }
                if (isDigit)
                {
                    i--;
                    if (signs.TryPeek(out var sign))
                    {
                        if (sign == '*')
                        {
                            digit = digits.Pop() * digit;
                            signs.Pop();
                        }
                        else if (sign == '/')
                        {
                            digit = digits.Pop() / digit;
                            signs.Pop();
                        }
                    }
                    digits.Push(digit);
                    continue;
                }

                signs.Push(c);
            }

            var result = 0;
            while (signs.TryPop(out var sign))
            {
                var digit = digits.Pop();
                if (sign == '+')
                {
                    result += digit;
                }
                else
                {
                    result -= digit;
                }
            }
            return result + digits.Pop();
        }
    }

    internal interface ISolution
    {
        int Calculate(string s);
    }
}
