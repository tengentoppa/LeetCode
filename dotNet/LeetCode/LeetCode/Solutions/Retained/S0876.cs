
using LeetCode.Helper;
using LeetCode.Interface;
using LeetCode.Type;

namespace Solutions.S0876
{
    public class Info : ILeetInfo
    {
        public string Problem => "Middle of the Linked List";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.LinkedList,
            TopicType.TwoPointers
        };
    }

    public class Solution : ILeet
    {
        readonly int[] head = { 1, 2, 3, 4, 5, 6 };

        public object Input
        {
            get => new
            {
                head
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.MiddleNode(head.ToListNode());
        }
    }
    public class Solution1 : ISolution
    {
        public ListNode MiddleNode(ListNode head)
        {
            var ptr1 = head;
            var ptr2 = head;
            while (ptr2?.next != null)
            {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next.next;
            }

            return ptr1;
        }
    }

    internal interface ISolution
    {
        ListNode MiddleNode(ListNode head);
    }
}
