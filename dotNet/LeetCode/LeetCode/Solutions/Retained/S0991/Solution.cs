
using LeetCode.Interface;

namespace Solutions.S0991
{
    public class Solution : ILeet
    {
        //readonly int n = (int)Math.Pow(10, 5);
        //readonly int k = 26 * (int)Math.Pow(10, 5);
        readonly int startValue = 5;
        readonly int target = 53453;

        public object Input
        {
            get => new
            {
                startValue,
                target,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.BrokenCalc(startValue, target);
        }
    }
    public class Solution1 : ISolution
    {
        public int BrokenCalc(int startValue, int target)
        {
            var ans = 0;
            while (target > startValue)
            {
                ans++;
                if (target % 2 == 1)
                {
                    target++;
                }
                else
                {
                    target /= 2;
                }
            }

            return ans + startValue - target;
        }
    }

    internal interface ISolution
    {
        int BrokenCalc(int startValue, int target);
    }
}
