
using LeetCode.Interface;
using Newtonsoft.Json;
using System.Text;

namespace Solutions.S1029
{
    public class Solution : ILeet
    {
        private readonly int[][] costs = JsonConvert.DeserializeObject<int[][]>("[[515,563],[451,713],[537,709],[343,819],[855,779],[457,60],[650,359],[631,42]]");

        public object Input
        {
            get => new
            {
                costs,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.TwoCitySchedCost(costs);
        }
    }
    public class Solution1 : ISolution
    {
        public int TwoCitySchedCost(int[][] costs)
        {
            var sCosts = costs.OrderBy(d => d[0] - d[1]);
            var halfLen = costs.Length / 2;
            return sCosts.Take(halfLen).Sum(d => d[0]) + sCosts.Skip(halfLen).Sum(d => d[1]);
        }
    }

    public interface ISolution
    {
        int TwoCitySchedCost(int[][] costs);
    }
}
