
using LeetCode.Interface;
using System.Text;

namespace Solutions.S0071
{
    public class Info : ILeetInfo
    {
        public string Problem => "Simplify Path";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.String,
            TopicType.Stack
        };
    }

    public class Solution : ILeet
    {
        /*
            "/home/"
            "/../"
            "/home//foo/"
            "/"
            "/a/./b/../../c/"
            "/.abc/"
        */
        readonly string str = "/a/./b//../../c/";

        public object Input
        {
            get => new
            {
                str,
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.SimplifyPath(str);
        }
    }
    public class Solution1 : ISolution
    {
        public string SimplifyPath(string path)
        {
            var stack = new Stack<string>();
            for (var i = 0; i < path.Length; i++)
            {
                if (path[i] == '/')
                {
                    continue;
                }
                var name = "";
                while (i < path.Length && path[i] != '/')
                {
                    name += path[i++];
                }

                if (name == ".")
                {
                    continue;
                }
                else if (name == "..")
                {
                    stack.TryPop(out var a);
                    continue;
                }

                stack.Push(name);
            }

            var result = "";
            while (stack.TryPop(out var p))
            {
                result = '/' + p + result;
            }
            if (result == "")
            {
                result = "/";
            }

            return result;
        }
    }

    internal interface ISolution
    {
        string SimplifyPath(string path);
    }
}
