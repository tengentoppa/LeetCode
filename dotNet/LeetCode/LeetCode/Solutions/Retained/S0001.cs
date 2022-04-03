
using LeetCode.Interface;

namespace Solutions.S0001
{
    public class Info : ILeetInfo
    {
        public string Problem => "Two Sum";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.HashTable
        };
    }
    public class Solution : ILeet
    {
        readonly int[] nums = { 1, 2, 3, 3 };
        readonly int target = 6;

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

            return solution.TwoSum(nums, target);
        }
    }
    public class Solution1 : ISolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var pos = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                var left = target - n;
                if (pos.ContainsKey(left))
                {
                    return new int[] { pos[left], i };
                }
                if (!pos.ContainsKey(n)) { pos[n] = i; }
            }
            return null;
        }
    }

    internal interface ISolution
    {
        int[] TwoSum(int[] nums, int target);
    }
}
