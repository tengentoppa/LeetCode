
using LeetCode.Interface;

namespace Solutions.S1337
{
    public class Solution : ILeet
    {
        readonly int[][] mat = {
            new int[]{1,1,0,0,0},
            new int[]{1,1,1,1,0},
            new int[]{1,0,0,0,0},
            new int[]{1,1,0,0,0},
            new int[]{1,1,1,1,1}
        };
        readonly int k = 3;

        public object Input
        {
            get => new
            {
                mat,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.KWeakestRows(mat, k);
        }
    }
    public class Solution1 : ISolution
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < mat.Length; i++)
            {
                var sCount = default(int);
                var row = mat[i];
                sCount = BinarySearch(row);
                if (dict.ContainsKey(sCount))
                {
                    dict[sCount].Add(i);
                }
                else
                {
                    dict.Add(sCount, new List<int> { i });
                }
            }
            var ans = new int[k];
            var sortedDict = dict.OrderBy(d => d.Key);
            var ansPos = 0;
            foreach (var rowLen in sortedDict)
            {
                foreach (var pos in rowLen.Value)
                {
                    ans[ansPos++] = pos;
                    if (ansPos == k) return ans;
                }
            }

            return ans;
        }
        private static int BinarySearch(int[] row)
        {
            int low = 0;
            int high = row.Length;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (row[mid] == 1)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }
    }

    internal interface ISolution
    {
        int[] KWeakestRows(int[][] mat, int k);
    }
}
