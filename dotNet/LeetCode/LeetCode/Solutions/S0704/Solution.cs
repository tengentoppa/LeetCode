
using LeetCode.Interface;

namespace Solutions.S0704
{
    public class Solution : ILeet
    {
        readonly int[] nums = { -1, 0, 3, 5, 9, 12 };
        readonly int target = 13;

        public object Input
        {
            get => new
            {
                nums,
                target
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.Search(nums, target);
        }
    }
    public class Solution1 : ISolution
    {
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int pivot = left + (right - left) / 2;
                var p = nums[pivot];
                if (p == target) return pivot;
                if (target < p) right = pivot - 1;
                else left = pivot + 1;
            }
            return -1;
        }
    }

    internal interface ISolution
    {
        int Search(int[] nums, int target);
    }
}
