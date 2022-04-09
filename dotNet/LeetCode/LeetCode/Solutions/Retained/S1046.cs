
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S1046
{
    public class Info : ILeetInfo
    {
        public string Problem => "Last Stone Weight";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.Heap_PriorityQueue
        };
    }

    public class Solution : ILeet
    {
        readonly int[] stones = JsonConvert.DeserializeObject<int[]>("[2,7,4,1,8,1]")!;

        public object Input
        {
            get => new
            {
                stones
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.LastStoneWeight(stones);
        }
    }
    public class Solution1 : ISolution
    {
        public int LastStoneWeight(int[] stones)
        {
            var q = new PriorityQueue<int, int>(stones.Select(x => (x, -x)));

            while (q.Count > 1)
            {
                int a = Math.Abs(q.Dequeue() - q.Dequeue());
                if (a != 0)
                    q.Enqueue(a, -a);
            }

            return (q.Count == 0) ? 0 : q.Peek();
        }
    }

    internal interface ISolution
    {
        int LastStoneWeight(int[] stones);
    }
}
