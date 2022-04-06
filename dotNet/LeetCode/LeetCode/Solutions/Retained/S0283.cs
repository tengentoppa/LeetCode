
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0283
{
    public class Info : ILeetInfo
    {
        public string Problem => "Move Zeroes";

        public Difficulty Difficulty => Difficulty.Easy;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.TwoPointers
        };
    }

    public class Solution : ILeet
    {
        readonly int[] input = JsonConvert.DeserializeObject<int[]>("[0,1,0,3,12]")!;

        public object Input
        {
            get => new
            {
                input
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();
            solution.MoveZeroes(input);
            return input;
        }
    }
    public class Solution1 : ISolution
    {
        public void MoveZeroes(int[] nums)
        {
            int lastNoneZeroPos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[lastNoneZeroPos++] = nums[i];
                }
            }

            for (int i = lastNoneZeroPos; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
    public class Solution2 : ISolution
    {
        public void MoveZeroes(int[] nums)
        {
            int j = -1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == 0)
                {
                    if (j == -1) j = i + 1;
                    while (j < nums.Length && nums[j] == 0)
                    {
                        j++;
                    }
                    if (j >= nums.Length) return;
                    var tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                }
            }
        }
    }

    internal interface ISolution
    {
        void MoveZeroes(int[] nums);
    }
}
