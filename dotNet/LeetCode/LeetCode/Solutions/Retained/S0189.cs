
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0189
{
    public class Info : ILeetInfo
    {
        public string Problem => "Rotate Array";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.LinkedList,
            TopicType.TwoPointers
        };
    }

    public class Solution : ILeet
    {
        readonly int[] input = JsonConvert.DeserializeObject<int[]>("[1,2,3,4,5,6,7]")!;
        readonly int k = 3;

        public object Input
        {
            get => new
            {
                input,
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
            solution.Rotate(input, k);
            return input;
        }
    }
    public class Solution1 : ISolution
    {
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            var count = 0;

            for (int i = 0; count < nums.Length; i++)
            {
                var current = i;
                var prev = nums[i];
                do
                {
                    var next = (current + k) % nums.Length;
                    var tmp = nums[next];
                    nums[next] = prev;
                    prev = tmp;
                    current = next;
                    count++;
                } while (current != i);
            }
        }
    }

    internal interface ISolution
    {
        void Rotate(int[] nums, int k);
    }
}
