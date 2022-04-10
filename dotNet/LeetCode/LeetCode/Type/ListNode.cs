namespace LeetCode.Type
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = default, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class ListNode<T>
    {
        public T val;
        public ListNode<T>? next;
        public ListNode(T val = default(T)!, ListNode<T>? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
