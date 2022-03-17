// See https://aka.ms/new-console-template for more information
ISolution solution = new Solution1();

var str = "(((())()))";

Console.WriteLine(solution.ScoreOfParentheses(str));

public class Solution1 : ISolution
{
    public int ScoreOfParentheses(string s)
    {
        var bal = 0;
        var ans = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                bal++;
            }
            else
            {
                bal--;
                if (s[i - 1] == '(')
                {
                    ans += 1 << bal;
                }
            }
        }
        return ans;
    }
}

internal interface ISolution
{
    int ScoreOfParentheses(string s);
}