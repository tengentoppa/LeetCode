
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0031
{
    public class Info : ILeetInfo
    {
        public string Problem => "Binary Search";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.BinarySearch
        };
    }

    public class Solution : ILeet
    {
        readonly int[] nums = JsonConvert.DeserializeObject<int[]>("[1,2,5,3,4]")!;

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

            solution.NextPermutation(nums);
            return nums;
        }
    }
    public class Solution1 : ISolution
    {
        public void NextPermutation(int[] nums)
        {
            var i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                var tmp = nums[j];
                nums[j] = nums[i];
                nums[i] = tmp;
            }
            i++;
            var k = nums.Length - 1;
            while (i < k)
            {
                var tmp = nums[k];
                nums[k] = nums[i];
                nums[i] = tmp;
                i++;
                k--;
            }
        }
    }

    internal interface ISolution
    {
        void NextPermutation(int[] nums);
    }
}
