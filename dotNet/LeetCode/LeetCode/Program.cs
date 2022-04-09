using LeetCode.Interface;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.RegularExpressions;

namespace LeetCode
{
    public enum Command
    {
        Help,
        List,
        Info,
        Exit,
    }

    public class Program
    {
        static string AvalibleCommands => string.Join(", ", Enum.GetNames(typeof(Command)));

        public static void Main(string[] args)
        {

            var input = default(string);
            //input = "2";

            if (input == null)
            {
                #region Init instance
                var doneList = GetSolutionList() ?? new List<string>();
                var doneInfos = GetSolutionInfos(doneList);
                var doneInfoList = doneList.Zip(doneInfos, (num, info) => new { num, info });
                #endregion
                Console.WriteLine("Welcome to Leet practice");
                Console.WriteLine("Avalible commands below");
                Console.WriteLine(AvalibleCommands);

                while (true)
                {
                    Console.WriteLine($"{new string('-', 40)}\nType Some Command");
                    input = Console.ReadLine();
                    var (cmd, arg) = ParseCommand(input ?? "");

                    switch (cmd)
                    {
                        case Command.Help:
                            Console.WriteLine(string.Join(", ", Enum.GetNames(typeof(Command))));
                            break;
                        case Command.List:
                            Console.WriteLine($"Done list:\n{string.Join($"\n", doneInfoList.Select(d => $"{d.num}, {d.info.Problem}"))}");
                            break;
                        case Command.Info:

                            break;
                        case Command.Exit:
                            return;

                        default:
                            Console.WriteLine("Invalid Input");
                            Console.WriteLine("Use commands below");
                            Console.WriteLine(AvalibleCommands);
                            break;
                    }

                }
            }
            else
            {
                RunResult(input!.Split(',').Select(d => d.Trim().PadLeft(4, '0')));
            }
        }

        static (Command cmd, IEnumerable<string> arg) ParseCommand(string input)
        {
            var raw = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (raw.Length == 0)
            {
                return ((Command)(-1), new List<string>());
            }

            var command = raw[0];
            var args = raw.Skip(1);

            if (!Enum.TryParse(typeof(Command), command, true, out var cmd))
            {
                return ((Command)(-1), new List<string>());
            }
            return ((Command)cmd!, args);
        }

        static void RunResult(IEnumerable<string> questionNumbers)
        {
            var funcs = questionNumbers.Select(d => new { qn = d, instance = GetLeet(d) });
            var unsupported = funcs.Where(d => d.instance == null);
            var supported = funcs.Where(d => d.instance != null);
            if (unsupported.Any())
            {
                Console.WriteLine($"\nUnsupport input: {string.Join(", ", unsupported.Select(d => d.qn))}");
            }

            foreach (var i in supported)
            {
                Console.WriteLine(new string('-', 80));

                var instance = i.instance;

                Console.WriteLine($"leet question number: {i.qn}\n" +
                    $"Input: {JsonConvert.SerializeObject(instance!.Input)}\n" +
                    $"Output: {JsonConvert.SerializeObject(instance!.Output)}");
            }
        }

        static IEnumerable<ILeetInfo> GetSolutionInfos(IEnumerable<string> problemNums)
        {
            return problemNums
                .Select(d => Type.GetType($"Solutions.S{d.PadLeft(4, '0')}.Info"))
                .Where(d => d != null)
                .Select(d => (ILeetInfo)Activator.CreateInstance(d!)!);
        }

        static IEnumerable<string>? GetSolutionList()
        {
            return Assembly.GetAssembly(typeof(ILeet))?
                .GetTypes()
                .Select(d => Regex.Match(d?.FullName ?? "", "^Solutions\\.S([\\d]{4}).Solution$"))
                .Select(d => d.Success ? d.Result("$1") : string.Empty)
                .Where(d => d != string.Empty)
                .OrderBy(d => d)
                .Select(d => d.TrimStart('0'));
        }

        static ILeet? GetLeet(string questionNumber)
        {
            var t = Type.GetType($"Solutions.S{questionNumber}.Solution");
            if (t == null)
            {
                return null;
            }
            ILeet instance = (ILeet)Activator.CreateInstance(t)!;
            return instance;
        }
    }
}