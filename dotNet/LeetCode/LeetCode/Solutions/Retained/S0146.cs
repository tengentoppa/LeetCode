
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0146
{
    public class Solution : ILeet
    {
        readonly string[] commands = new string[] { "LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get" };
        readonly int[][] nums = JsonConvert.DeserializeObject<int[][]>("[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]")!;

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
            ISolution solution = default(LRUCache);
            var result = new List<string>();
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "LRUCache":
                        solution = new LRUCache(nums[i][0]);
                        result.Add($"LRUCache");
                        break;
                    case "get":
                        var n = solution!.Get(nums[i][0]);
                        result.Add($"get {nums[i][0]}~{n}");
                        break;
                    case "put":
                        solution!.Put(nums[i][0], nums[i][1]);
                        result.Add($"put {nums[i][0]}~{nums[i][1]}");
                        break;
                }
            }

            return string.Join(", ", result);
        }
    }
    public class LRUCache : ISolution
    {
        private readonly int capacity;
        private int size;
        private readonly Dictionary<int, LinkedListNode<Node>> cache;
        private readonly LinkedList<Node> nodes;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            cache = new();
            nodes = new();
        }

        public int Get(int key)
        {
            if (!cache.ContainsKey(key)) return -1;
            var node = cache[key];
            nodes.Remove(node);
            nodes.AddFirst(node);
            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                var node = cache[key];
                node.Value.Value = value;
                nodes.Remove(node);
                nodes.AddFirst(node);
                return;
            }
            if (size == capacity)
            {
                cache.Remove(nodes.Last!.Value.Key);
                nodes.RemoveLast();
                size--;
            }
            nodes.AddFirst(new Node { Key = key, Value = value });
            cache[key] = nodes.First!;
            size++;
        }

        private class Node
        {
            public int Key { get; set; }
            public int Value { get; set; }
        }
    }

    public interface ISolution
    {
        int Get(int key);
        void Put(int key, int value);
    }
}
