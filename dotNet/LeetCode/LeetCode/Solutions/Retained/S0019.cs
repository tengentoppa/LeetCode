
using LeetCode.Helper;
using LeetCode.Interface;
using LeetCode.Type;

namespace Solutions.S0019
{
    public class Info : ILeetInfo
    {
        public string Problem => "Remove Nth Node From End of List";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.LinkedList,
            TopicType.TwoPointers
        };
    }

    public class Solution : ILeet
    {
        readonly int[] head = { 1, 2, 3, 4, 5 };
        readonly int n = 4;

        public object Input
        {
            get => new
            {
                head,
                n
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.RemoveNthFromEnd(head.ToListNode(), n);
        }
    }
    public class Solution1 : ISolution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var slow = head;
            var fast = head;
            while (n-- > 0)
            {
                fast = fast.next;
            }

            var preNode = default(ListNode);
            while (fast != null)
            {
                preNode = slow;
                slow = slow.next;
                fast = fast.next;
            }

            if (preNode == null)
            {
                return slow.next;
            }
            else
            {
                preNode.next = preNode.next.next;
            }

            return head;
        }
    }

    internal interface ISolution
    {
        ListNode RemoveNthFromEnd(ListNode head, int n);
    }
}
