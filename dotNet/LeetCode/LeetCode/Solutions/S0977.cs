
using LeetCode.Interface;

namespace Solutions.S0977
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
        readonly int[] nums = new int[] { -4, -1, 0, 3, 10 };

        public object Input
        {
            get => new
            {
                nums
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.SortedSquares(nums);
        }
    }
    public class Solution1 : ISolution
    {
        public int[] SortedSquares(int[] nums)
        {
            var len = nums.Length;
            var left = 0;
            var right = len - 1;
            var result = new int[len];
            var square = 0;

            for (var i = len - 1; i >= 0; i--)
            {
                if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
                {
                    square = nums[right];
                    right--;
                }
                else
                {
                    square = nums[left];
                    left++;
                }
                result[i] = square * square;
            }
            return result;
        }
    }

    internal interface ISolution
    {
        int[] SortedSquares(int[] nums);
    }
}
