
using LeetCode.Interface;

namespace Solutions.S895
{
    public class Solution : ILeet
    {
        readonly string[] commands = new string[] { "FreqStack", "push", "push", "push", "push", "push", "push", "pop", "pop", "pop", "pop" };
        readonly int?[] nums = new int?[] { null, 5, 7, 5, 7, 4, 5, null, null, null, null };

        public object Input
        {
            get => new
            {
                commands,
                nums
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();
            var result = new List<string>();
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "FreqStack":
                        solution = new Solution1();
                        result.Add($"FreqStack");
                        break;
                    case "push":
                        solution.Push(nums[i] ?? -1);
                        result.Add($"push {nums[i]}");
                        break;
                    case "pop":
                        var n = solution.Pop();
                        result.Add($"pop {n}");
                        break;
                }
            }

            return string.Join(", ", result);
        }
    }
    public class Solution1 : ISolution
    {
        private readonly Dictionary<int, int> freqs;
        private readonly Dictionary<int, Stack<int>> group;
        private int maxFreq;
        public Solution1()
        {
            freqs = new Dictionary<int, int>();
            group = new Dictionary<int, Stack<int>>();
            maxFreq = 0;
        }

        public void Push(int val)
        {
            freqs.TryGetValue(val, out var freq);
            freqs[val] = ++freq;
            if (freq > maxFreq)
            {
                maxFreq = freq;
            }

            if (group.ContainsKey(freq))
            {
                group[freq].Push(val);
            }
            else
            {
                var s = new Stack<int>();
                s.Push(val);
                group.Add(freq, s);
            }
        }

        public int Pop()
        {
            var result = group[maxFreq].Pop();
            freqs[result]--;
            if (group[maxFreq].Count == 0)
            {
                maxFreq--;
            }
            return result;
        }
    }

    public interface ISolution
    {
        void Push(int val);
        int Pop();
    }
}
