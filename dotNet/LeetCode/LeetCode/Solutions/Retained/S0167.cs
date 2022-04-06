
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0167
{
    public class Info : ILeetInfo
    {
        public string Problem => "Two Sum II - Input Array Is Sorted";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.TwoPointers,
            TopicType.BinarySearch
        };
    }

    public class Solution : ILeet
    {
        readonly int[] numbers = JsonConvert.DeserializeObject<int[]>("[2,7,11,15]")!;
        readonly int target = 9;

        public object Input
        {
            get => new
            {
                numbers,
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

            return solution.TwoSum(numbers, target);
        }
    }
    public class Solution1 : ISolution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (left < right)
            {
                var sum = numbers[left] + numbers[right];

                if (sum == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return new int[] { -1, -1 };
        }
    }

    internal interface ISolution
    {
        int[] TwoSum(int[] numbers, int target);
    }
}
