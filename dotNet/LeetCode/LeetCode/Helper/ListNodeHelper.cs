using LeetCode.Type;

namespace LeetCode.Helper
{
    public static class ListNodeHelper
    {
        public static ListNode ToListNode(this IEnumerable<int> input)
        {
            var listNode = new ListNode(input.ElementAt(0));
            var pre = listNode;
            foreach (var i in input.Skip(1))
            {
                var tmp = new ListNode(i);
                pre.next = tmp;
                pre = tmp;
            }
            return listNode;
        }
        public static ListNode<T> ToListNode<T>(this IEnumerable<T> input)
        {
            var listNode = new ListNode<T>(input.ElementAt(0));
            var pre = listNode;
            foreach (var i in input.Skip(1))
            {
                var tmp = new ListNode<T>(i);
                pre.next = tmp;
                pre = tmp;
            }
            return listNode;
        }
    }
}
