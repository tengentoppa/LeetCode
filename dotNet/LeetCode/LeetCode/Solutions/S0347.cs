
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0347
{
    public class Info : ILeetInfo
    {
        public string Problem => "Top K Frequent Elements";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.HashTable,
            TopicType.DivideandConquer,
            TopicType.Sorting,
            TopicType.Heap_PriorityQueue,
            TopicType.BucketSort,
            TopicType.Counting,
            TopicType.Quickselect
        };
    }

    public class Solution : ILeet
    {
        readonly int[] nums = JsonConvert.DeserializeObject<int[]>("[1,1,1,2,2,3]")!;
        readonly int k = 2;

        public object Input
        {
            get => new
            {
                nums,
                k
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.TopKFrequent(nums, k);
        }
    }
    public class Solution1 : ISolution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums.Length == k)
            {
                return nums;
            }
            return nums
                .GroupBy(d => d)
                .ToDictionary(d => d.Key, d => d.Count())
                .OrderByDescending(d => d.Value)
                .Take(k)
                .Select(d => d.Key)
                .ToArray();
        }
    }

    internal interface ISolution
    {
        int[] TopKFrequent(int[] nums, int k);
    }
}
