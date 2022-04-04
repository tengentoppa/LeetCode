
using LeetCode.Interface;

namespace Solutions.S0278
{
    public class Info : ILeetInfo
    {
        public string Problem => "First Bad Version";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.BinarySearch,
            TopicType.Interactive
        };
    }

    public class Solution : ILeet
    {
        readonly int n = 5;
        readonly int bad = 4;

        public object Input
        {
            get => new
            {
                n,
                bad,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1(bad);

            return solution.FirstBadVersion(n);
        }
    }
    public class Solution1 : VersionControl, ISolution
    {
        public Solution1(int n) : base(n) { }
        public int FirstBadVersion(int n)
        {
            var left = 1;
            var right = n;
            var lastBad = 0;

            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    lastBad = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return lastBad;
        }
    }

    public class VersionControl
    {
        private readonly int Bad;
        public VersionControl(int bad)
        {
            Bad = bad;
        }

        protected bool IsBadVersion(int version)
        {
            return Bad <= version;
        }
    }

    internal interface ISolution
    {
        int FirstBadVersion(int n);
    }
}
