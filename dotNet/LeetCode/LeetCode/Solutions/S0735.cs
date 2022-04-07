
using LeetCode.Interface;
using Newtonsoft.Json;

namespace Solutions.S0735
{
    public class Info : ILeetInfo
    {
        public string Problem => "Asteroid Collision";

        public Difficulty Difficulty => Difficulty.Medium;

        public TopicType[] Topics => new TopicType[]
        {
            TopicType.Array,
            TopicType.Stack
        };
    }

    public class Solution : ILeet
    {
        readonly int[] asteroids = JsonConvert.DeserializeObject<int[]>("[5,10,-5]")!;

        public object Input
        {
            get => new
            {
                asteroids
            };
        }

        public object Output
        {
            get => Run();
        }

        public object Run()
        {
            ISolution solution = new Solution1();

            return solution.AsteroidCollision(asteroids);
        }
    }
    public class Solution1 : ISolution
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();
            var result = new List<int>();
            for (var i = 0; i < asteroids.Length; i++)
            {
                var asteroid = asteroids[i];
                if (asteroid > 0)
                {
                    stack.Push(asteroid);
                }
                else
                {
                    while (stack.TryPeek(out var toRight))
                    {
                        if (toRight < -asteroid)
                        {
                            stack.Pop();
                        }
                        else if (toRight == -asteroid)
                        {
                            asteroid = 0;
                            stack.Pop();
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (stack.Count() == 0 && asteroid != 0)
                    {
                        result.Add(asteroid);
                    }
                }
            }

            var count = result.Count();
            while (stack.TryPop(out var p))
            {
                result.Insert(count, p);
            }
            return result.ToArray();
        }
    }

    internal interface ISolution
    {
        int[] AsteroidCollision(int[] asteroids);
    }
}
