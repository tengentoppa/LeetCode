
using LeetCode.Interface;

namespace Solutions.S0081
{
    public class Info : ILeetInfo
    {
        public string Problem => "Search in Rotated Sorted Array II";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.BinarySearch
        };
    }

    public class Solution : ILeet
    {
        readonly int[] nums = new int[] { 2, 5, 6, 0, 0, 1, 2 };
        readonly int target = 3;

        public object Input
        {
            get => new
            {
                nums,
                target
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.Search(nums, target);
        }
    }
    public class Solution1 : ISolution
    {
        public bool Search(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0) return false;
            int right = n - 1;
            int left = 0;

            // 1. left to mid ordered and target is in [left, mid] 
            // 2. left to mid ordered but target in the other side [mid, right]
            // 3. right to mid ordered, target in [mid, right]
            // 4. right to mid ordered but in the other side in [left, mid]
            while (left + 1 < right)
            {
                while (left + 1 < right && nums[left] == nums[left + 1])
                {
                    left++;
                }
                while (left + 1 < right && nums[right] == nums[right - 1])
                {
                    right--;
                }
                if (left + 1 >= right) break;

                int mid = (right - left) / 2 + left;

                if (nums[mid] == target)
                {
                    return true;
                }
                if (nums[mid] > nums[left])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid;
                    }
                }
                // mid to right ordered
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid;
                    }
                }
            }
            if (nums[left] == target || nums[right] == target)
            {
                return true;
            }
            return false;
        }
    }
    public class Solution2 : ISolution
    {
        public bool Search(int[] nums, int target)
        {
            return nums.Any(d => d == target);
        }
    }

    internal interface ISolution
    {
        bool Search(int[] nums, int target);
    }
}
