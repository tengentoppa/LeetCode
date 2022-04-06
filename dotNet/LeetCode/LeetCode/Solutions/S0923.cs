
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0923
{
    public class Info : ILeetInfo
    {
        public string Problem => "3Sum With Multiplicity";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.HashTable,
            TopicType.TwoPointers,
            TopicType.Sorting,
            TopicType.Counting
        };
    }

    public class Solution : ILeet
    {
        readonly int[] arr = JsonConvert.DeserializeObject<int[]>("[92,4,59,23,100,16,7,15,3,78,98,17,77,33,83,15,87,35,54,72,58,14,87,47,58,31,72,58,87,22,25,54,27,53,13,54,61,12,96,24,35,43,94,1,88,76,89,89,41,56,61,65,60,91,89,79,86,52,27,2,97,46,50,46,87,93,71,87,95,78,65,10,35,51,34,66,61,7,49,38,10,1,88,37,50,84,35,20,7,83,51,85,11,12,89,93,54,23,36,95,100,19,82,67,96,77,53,56,51,16,54,7,30,68,78,13,38,52,91,44,54,17,21,44,4,10,85,19,11,88,73,36,47,53,3,21,41,24,60,53,88,35,48,89,35,3,43,85,45,67,56,78,44,49,29,35,68,96,29,21,51,17,52,99,3,48,65,51,22,38,77,81,30,64,99,35,88,72,73,29,29,2]")!;
        readonly int target = 105;

        public object Input
        {
            get => new
            {
                arr,
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

            return solution.ThreeSumMulti(arr, target);
        }
    }
    public class Solution1 : ISolution
    {
        public int ThreeSumMulti(int[] arr, int target)
        {
            var dic = Enumerable.Repeat(0, 101).ToArray();
            var unique = new List<int>();

            foreach (var i in arr)
            {
                if (dic[i] == 0)
                {
                    unique.Add(i);
                }
                dic[i]++;
            }
            unique.Sort();

            long ans = 0;
            for (var i = 0; i < unique.Count; i++)
            {
                for (var j = i; j < unique.Count; j++)
                {
                    var a = unique[i];
                    var b = unique[j];
                    var t = target - a - b;
                    if (t < b) break;
                    if (t > 100) continue; // Prevent t go over dic range
                    if (dic[t] > 0)
                    {
                        ans += Combination(a, b, t, dic) % 1000000007;
                    }
                }
            }

            return (int)ans;
        }
        private static long Combination(int a, int b, int c, int[] dic)
        {
            var result = default(long);
            if (a == b && a == c)
            {
                result = (long)dic[a] * (dic[a] - 1) * (dic[a] - 2) / 6;
            }
            else if (a == b)
            {
                result = (long)dic[a] * (dic[a] - 1) * dic[c] / 2;
            }
            else if (b == c)
            {
                result = (long)dic[a] * dic[b] * (dic[b] - 1) / 2;
            }
            else
            {
                result = (long)dic[a] * dic[b] * dic[c];
            }
            return result % 1000000007;
        }
    }

    internal interface ISolution
    {
        int ThreeSumMulti(int[] arr, int target);
    }
}
