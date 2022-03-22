
using LeetCode.Interface;

namespace Solutions.S1663
{
    public class Solution : ILeet
    {
        //readonly int n = (int)Math.Pow(10, 5);
        //readonly int k = 26 * (int)Math.Pow(10, 5);
        readonly int n = 23100;
        readonly int k = 567226;

        public object Input
        {
            get => new
            {
                n,
                k,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.GetSmallestString(n, k);
        }
    }
    public class Solution1 : ISolution
    {
        public string GetSmallestString(int n, int k)
        {
            k -= n;
            var zCount = k / 25;
            var value = k % 25;

            var aCount = n - zCount;
            if (value > 0) aCount--;
            var aStr = aCount > 0 ? new string('a', aCount) : "";
            var valueStr = value > 0 ? ((char)('a' + value)).ToString() : "";


            return aStr + valueStr + new string('z', zCount);
        }
    }

    internal interface ISolution
    {
        string GetSmallestString(int n, int k);
    }
}
