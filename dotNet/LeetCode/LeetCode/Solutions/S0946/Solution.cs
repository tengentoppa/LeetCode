
using LeetCode.Interface;

namespace Solutions.S0946
{
    public class Solution : ILeet
    {
        readonly int[] pushed = new int[] { 1, 2, 3, 4, 5 };
        readonly int[] popped = new int[] { 4, 5, 3, 2, 1 };

        public object Input
        {
            get => new
            {
                pushed,
                popped
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.MinRemoveToMakeValid(pushed, popped);
        }
    }
    public class Solution1 : ISolution
    {
        public bool MinRemoveToMakeValid(int[] pushed, int[] popped)
        {
            var stack = new Stack<int>();
            var len = pushed.Length;
            var indexPopped = 0;

            foreach (var p in pushed)
            {
                stack.Push(p);

                while (stack.Any() &&
                    stack.Peek() == popped[indexPopped])
                {
                    stack.Pop();
                    ++indexPopped;
                }
            }

            return indexPopped == len;
        }
    }

    public interface ISolution
    {
        bool MinRemoveToMakeValid(int[] pushed, int[] popped);
    }
}
