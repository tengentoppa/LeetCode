// See https://aka.ms/new-console-template for more information
using System.Text;
ISolution solution = new Solution1();
Console.WriteLine(solution.MinRemoveToMakeValid("))(((123)432)"));

internal class Solution1 : ISolution
{
    public string MinRemoveToMakeValid(string s)
    {
        var stack = new Stack<KeyValuePair<int, char>>();
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (c == ')')
            {
                if (stack.Any() && stack.Peek().Value == '(')
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(new KeyValuePair<int, char>(i, ')'));
                }
            }
            else if (c == '(')
            {
                stack.Push(new KeyValuePair<int, char>(i, '('));
            }
        }

        var result = new StringBuilder(s);
        foreach (var stc in stack)
        {
            result.Remove(stc.Key, 1);
        }
        return result.ToString();
    }
}

internal interface ISolution
{
    string MinRemoveToMakeValid(string s);
}