// See https://aka.ms/new-console-template for more information
ISolution solution = new Solution1();

var pushed = new int[] { 1, 2, 3, 4, 5 };
var popped = new int[] { 4, 5, 3, 2, 1 };

Console.WriteLine(solution.MinRemoveToMakeValid(pushed, popped));

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

internal interface ISolution
{
    bool MinRemoveToMakeValid(int[] pushed, int[] popped);
}