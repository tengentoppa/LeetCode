
using LeetCode.Interface;

namespace Solutions.S0881
{
    public class Info : ILeetInfo
    {
        public string Problem => "Boats to Save People";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.TwoPointers,
            TopicType.Greedy,
            TopicType.Sorting
        };
    }

    public class Solution : ILeet
    {
        readonly int[] people = { 1, 1, 1 };
        readonly int limit = 3;

        public object Input
        {
            get => new
            {
                people,
                limit
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.NumRescueBoats(people, limit);
        }
    }
    public class Solution1 : ISolution
    {
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            var ans = 0;
            var i = 0;
            var j = people.Length - 1;
            while (i <= j)
            {
                ans++;
                if (people[i] + people[j] <= limit)
                {
                    i++;
                }
                j--;
            }
            return ans;
        }
    }

    internal interface ISolution
    {
        int NumRescueBoats(int[] people, int limit);
    }
}
