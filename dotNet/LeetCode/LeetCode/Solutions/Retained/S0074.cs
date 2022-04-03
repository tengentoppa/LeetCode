
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0074
{
    public class Info : ILeetInfo
    {
        public string Problem => "Search a 2D Matrix";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[] {
            TopicType.Array,
            TopicType.BinarySearch,
            TopicType.Matrix };
    }
    public class Solution : ILeet
    {
        readonly int[][] nums = JsonConvert.DeserializeObject<int[][]>("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]")!;
        readonly int target = 7;

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

            var result = solution.SearchMatrix(nums, target);
            for (int i = 1; i < 70; i++)
            {
                Console.WriteLine($"{i}, {solution.SearchMatrix(nums, i)}");
            }

            return string.Join(", ", result);
        }
    }
    public class Solution1 : ISolution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var middle = 0;
            var left = 0;
            var right = matrix.Length - 1;
            var rowLast = matrix[0].Length - 1;

            while (left <= right)
            {
                middle = left + (right - left) / 2;
                if (matrix[middle][0] <= target && matrix[middle][rowLast] >= target) { break; }
                if (matrix[middle][0] > target) right = middle - 1;
                if (matrix[middle][rowLast] < target) left = middle + 1;
            }
            var row = matrix[middle];
            if (row[0] <= target && row[rowLast] >= target)
            {
                left = 0;
                right = rowLast;
                while (left <= right)
                {
                    middle = left + (right - left) / 2;
                    if (row[middle] == target) { return true; }
                    if (row[middle] > target) right = middle - 1;
                    if (row[middle] < target) left = middle + 1;
                }
            }
            return false;
        }
    }

    public interface ISolution
    {
        bool SearchMatrix(int[][] matrix, int target);
    }
}
