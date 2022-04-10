
using LeetCode.Interface;
using LeetCode.Type;

namespace Solutions.S0002
{
    public class Info : ILeetInfo
    {
        public string Problem => "Add Two Numbers";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.LinkedList,
            TopicType.Math,
            TopicType.Recursion
        };
    }

    public class Solution : ILeet
    {
        readonly int[] L1 = { 9, 9, 9, 9, 9, 9, 9 };
        readonly int[] L2 = { 9, 9, 9, 9 };

        public object Input
        {
            get => new
            {
                L1,
                L2
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();
            var l1 = new ListNode(L1[0]);
            var l2 = new ListNode(L2[0]);
            var pre = l1;
            foreach (var i in L1.Skip(1))
            {
                var tmp = new ListNode(i);
                pre.next = tmp;
                pre = tmp;
            }
            pre = l2;
            foreach (var i in L2.Skip(1))
            {
                var tmp = new ListNode(i);
                pre.next = tmp;
                pre = tmp;
            }

            return solution.AddTwoNumbers(l1, l2);
        }
    }
    public class Solution1 : ISolution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carry = 0;
            var dummyhead = new ListNode();
            var curr = dummyhead;
            while (l1 != null || l2 != null)
            {
                var sum = carry + (l1?.val ?? 0) + (l2?.val ?? 0);
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                l1 = l1?.next;
                l2 = l2?.next;
            }
            if (carry > 0) curr.next = new ListNode(carry);

            return dummyhead.next;
        }
    }

    internal interface ISolution
    {
        ListNode AddTwoNumbers(ListNode l1, ListNode l2);
    }
}
