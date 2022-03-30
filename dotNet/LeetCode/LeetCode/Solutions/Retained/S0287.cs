
using LeetCode.Interface;

namespace Solutions.S0287
{
    public class Infos : ILeetInfo
    {
        public string Problem => "Find the Duplicate Number";

        public TopicType[] Topics => new TopicType[] {
            TopicType.Array,
            TopicType.TwoPointers,
            TopicType.BinarySearch,
            TopicType.BitManipulation };
    }

    public class Solution : ILeet
    {
        readonly int[] nums = new int[] { 1, 3, 4, 2, 2 };

        public object Input
        {
            get => new
            {
                nums,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.FindDuplicate(nums);
        }
    }
    public class Solution1 : ISolution
    {
        public int FindDuplicate(int[] nums)
        {
            var tortoise = nums[0];
            var hare = nums[0];

            do
            {
                tortoise = nums[tortoise];
                hare = nums[nums[hare]];
            } while (tortoise != hare);

            tortoise = nums[0];

            while (tortoise != hare)
            {
                tortoise = nums[tortoise];
                hare = nums[hare];
            }

            return hare;
        }
    }
    public class Solution2 : ISolution
    {
        public int FindDuplicate(int[] nums)
        {
            var hashs = new HashSet<int>();
            foreach (var n in nums)
            {
                if (hashs.Contains(n))
                {
                    return n;
                }
                hashs.Add(n);
            }
            return -1;
        }
    }

    public interface ISolution
    {
        int FindDuplicate(int[] nums);
    }
}
