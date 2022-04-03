
using LeetCode.Interface;
//using Newtonsoft.Json;

namespace Solutions.S1007
{
    public class Info : ILeetInfo
    {
        public string Problem => "Minimum Domino Rotations For Equal Row";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.Greedy
        };
    }

    public class Solution : ILeet
    {
        readonly int[] tops = new int[] { 2, 1, 2, 4, 2, 2 };
        readonly int[] bottoms = new int[] { 5, 2, 6, 2, 3, 2 };

        public object Input
        {
            get => new
            {
                tops,
                bottoms
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.MinDominoRotations(tops, bottoms);
        }
    }
    public class Solution1 : ISolution
    {
        private readonly Dictionary<int, int> topOwn = new();
        private readonly Dictionary<int, int> bottomOwn = new();
        private readonly Dictionary<int, int> topVision = new();
        private readonly Dictionary<int, int> bottomVision = new();
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            //For debug
            //Func<object?, string> func = JsonConvert.SerializeObject; 
            int vt, vb;
            int tc, bc;
            int len = tops.Length;
            for (int i = 0; i < len; i++)
            {
                vt = tops[i];
                vb = bottoms[i];
                topOwn.TryGetValue(vt, out tc);
                bottomOwn.TryGetValue(vb, out bc);
                topOwn[vt] = tc + 1;
                bottomOwn[vb] = bc + 1;

                if (vt != vb)
                {
                    topVision.TryGetValue(vb, out tc);
                    bottomVision.TryGetValue(vt, out bc);

                    topVision[vb] = tc + 1;
                    bottomVision[vt] = bc + 1;
                }
                //Console.WriteLine($"{vt}, {vb}, {func(topOwn)}, {func(bottomOwn)}, {func(topVision)}, {func(bottomVision)}");
            }

            var result = int.MaxValue;
            for (int i = 1; i <= 6; i++)
            {
                topOwn.TryGetValue(i, out var to);
                topVision.TryGetValue(i, out var tv);
                if (to + tv == len && tv < result)
                {
                    result = tv;
                }

                bottomOwn.TryGetValue(i, out var bo);
                bottomVision.TryGetValue(i, out var bv);
                if (bo + bv == len && bv < result)
                {
                    result = bv;
                }
            }

            return result == int.MaxValue ? -1 : result;
        }
    }

    public interface ISolution
    {
        int MinDominoRotations(int[] tops, int[] bottoms);
    }
}
