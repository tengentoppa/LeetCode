
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0035
{
    public class Info : ILeetInfo
    {
        public string Problem => "Search Insert Position";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.BinarySearch
        };
    }

    public class Solution : ILeet
    {
        readonly int[] nums = JsonConvert.DeserializeObject<int[]>("[1,3,6,7]")!;
        readonly int target = 5;

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

            solution.SearchInsert(nums, target);
            return nums;
        }
    }
    public class Solution1 : ISolution
    {
        public int SearchInsert(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (target > nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left;
        }
    }

    internal interface ISolution
    {
        int SearchInsert(int[] nums, int target);
    }
}
