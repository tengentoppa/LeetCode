
using LeetCode.Helper;
using LeetCode.Interface;
using LeetCode.Type;
using Newtonsoft.Json;

namespace Solutions.S1721
{
    public class Info : ILeetInfo
    {
        public string Problem => "Swapping Nodes in a Linked List";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.LinkedList,
            TopicType.TwoPointers
        };
    }

    public class Solution : ILeet
    {
        readonly int[] input = JsonConvert.DeserializeObject<int[]>("[1,2,3,4,5]")!;
        readonly int k = 2;

        public object Input
        {
            get => new
            {
                input,
                k
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.SwapNodes(input.ToListNode(), k);
        }
    }
    public class Solution1 : ISolution
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            var curNode = head;
            var frontNode = default(ListNode);
            var endNode = default(ListNode);
            var count = 1;
            while (curNode != null)
            {
                if (endNode != null)
                {
                    endNode = endNode.next;
                }
                if (count == k)
                {
                    frontNode = curNode;
                    endNode = head;
                }

                count++;
                curNode = curNode.next;
            }

            (endNode!.val, frontNode!.val) = (frontNode.val, endNode.val);
            return head;
        }
    }
    public class Solution2 : ISolution
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            var count = 1;
            var pointer = head;
            while (pointer.next != null)
            {
                count++;
                pointer = pointer.next;
            }
            var com = count - k + 1;
            var high = Math.Max(com, k);
            var low = Math.Min(com, k);
            pointer = head;
            var node1 = RollLen(pointer, low - 1);
            var node2 = RollLen(node1, high - low);
            SwapNode(node1, node2);

            return head;
        }

        private static ListNode RollLen(ListNode node, int len)
        {
            while (len-- > 0)
            {
                node = node.next;
            }
            return node;
        }

        private static void SwapNode(ListNode node1, ListNode node2)
        {
            var tmp = node1.val;
            node1.val = node2.val;
            node2.val = tmp;
        }
    }

    internal interface ISolution
    {
        ListNode SwapNodes(ListNode head, int k);
    }
}
