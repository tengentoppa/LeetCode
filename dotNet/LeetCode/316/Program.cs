// See https://aka.ms/new-console-template for more information
using System.Text;

ISolution solution = new Solution1();

//var str = "bcabc";
var str = "cbacdcbc";

Console.WriteLine(solution.RemoveDuplicateLetters(str));

public class Solution1 : ISolution
{
    public string RemoveDuplicateLetters(string s)
    {
        bool[] visited = new bool[26];
        var stack = new Stack<char>();
        int[] freq = new int[26];
        foreach (char c in s)
        {
            freq[c - 'a'] += 1;
        }

        foreach (char c in s)
        {
            if (visited[c - 'a'])
            {
                freq[c - 'a'] -= 1;
                continue;
            }
            while (stack.Count != 0 && stack.Peek() > c && freq[stack.Peek() - 'a'] > 0)
            {
                visited[stack.Peek() - 'a'] = false;
                stack.Pop();
            }
            stack.Push(c);
            visited[c - 'a'] = true;
            freq[c - 'a'] -= 1;
        }
        StringBuilder sb = new StringBuilder();
        while (stack.Count > 0)
        {
            sb = sb.Insert(0, stack.Pop());
        }
        return sb.ToString();
    }
}

internal interface ISolution
{
    string RemoveDuplicateLetters(string s);
}