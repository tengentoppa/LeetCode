
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0011
{
    public class Info : ILeetInfo
    {
        public string Problem => "Container With Most Water";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.TwoPointers,
            TopicType.Greedy
        };
    }

    public class Solution : ILeet
    {
        readonly int[] height = JsonConvert.DeserializeObject<int[]>("[1,8,6,2,5,4,8,3,7]")!;

        public object Input
        {
            get => new
            {
                height
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();
            
            return solution.MaxArea(height);
        }
    }
    public class Solution1 : ISolution
    {
        public int MaxArea(int[] height)
        {
            var left = 0;
            var right = height.Length - 1;
            var max = 0;
            while (left < right)
            {
                max = Math.Max(max, Math.Min(height[left], height[right]) * (right - left));
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return max;
        }
    }

    internal interface ISolution
    {
        int MaxArea(int[] height);
    }
}
