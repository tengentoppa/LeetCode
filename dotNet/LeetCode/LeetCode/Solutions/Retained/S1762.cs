
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S1762
{
    public class Info : ILeetInfo
    {
        public string Problem => "Buildings With an Ocean View";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.Stack,
            TopicType.MonotonicStack
        };
    }

    public class Solution : ILeet
    {
        readonly int[] heights = JsonConvert.DeserializeObject<int[]>("[4,2,3,1]")!;

        public object Input
        {
            get => new
            {
                heights
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();
            
            return solution.FindBuildings(heights);
        }
    }
    public class Solution1 : ISolution
    {
        public int[] FindBuildings(int[] heights)
        {
            var max = -1;
            var stack = new Stack<int>();
            for (var i = heights.Length - 1; i >= 0; i--)
            {
                if (heights[i] > max)
                {
                    max = heights[i];
                    stack.Push(i);
                }
            }

            var result = new int[stack.Count()];
            var j = 0;
            while (stack.TryPop(out var p))
            {
                result[j++] = p;
            }
            return result;
        }
    }

    internal interface ISolution
    {
        int[] FindBuildings(int[] heights);
    }
}
