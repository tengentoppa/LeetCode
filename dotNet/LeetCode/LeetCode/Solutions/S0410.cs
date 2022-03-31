
using LeetCode.Interface;

namespace Solutions.S0410
{
    public class Solution : ILeet
    {
        readonly int[] nums = new int[] { 7, 2, 5, 10, 8 };
        readonly int m = 2;

        public object Input
        {
            get => new
            {
                nums,
                m
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.SplitArray(nums, m);
        }
    }
    public class Solution1 : ISolution
    {
        private static int MinimumSubarraysRequired(int[] nums, int maxSumAllowed)
        {
            int currentSum = 0;
            int splitsRequired = 0;

            foreach (var element in nums)
            {
                // Add element only if the sum doesn't exceed maxSumAllowed
                if (currentSum + element <= maxSumAllowed)
                {
                    currentSum += element;
                }
                else
                {
                    // If the element addition makes sum more than maxSumAllowed
                    // Increment the splits required and reset sum
                    currentSum = element;
                    splitsRequired++;
                }
            }

            // Return the number of subarrays, which is the number of splits + 1
            return splitsRequired + 1;
        }

        public int SplitArray(int[] nums, int m)
        {
            // Find the sum of all elements and the maximum element
            int sum = 0;
            int maxElement = int.MinValue;
            foreach (var element in nums)
            {
                sum += element;
                maxElement = Math.Max(maxElement, element);
            }

            // Define the left and right boundary of binary search
            int left = maxElement;
            int right = sum;
            int minimumLargestSplitSum = 0;
            while (left <= right)
            {
                // Find the mid value
                int maxSumAllowed = left + (right - left) / 2;

                // Find the minimum splits. If splitsRequired is less than
                // or equal to m move towards left i.e., smaller values
                if (MinimumSubarraysRequired(nums, maxSumAllowed) <= m)
                {
                    right = maxSumAllowed - 1;
                    minimumLargestSplitSum = maxSumAllowed;
                }
                else
                {
                    // Move towards right if splitsRequired is more than m
                    left = maxSumAllowed + 1;
                }
            }

            return minimumLargestSplitSum;
        }
    }

    internal interface ISolution
    {
        int SplitArray(int[] nums, int m);
    }
}
