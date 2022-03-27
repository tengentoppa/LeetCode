using LeetCode.Interface;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.RegularExpressions;

var input = default(string);
//input = "3";

if (input == null)
{
    Console.WriteLine($"Done list: {string.Join(", ", GetSolutionList() ?? new List<string>())}");
    Console.WriteLine("Give me some leet question numbers (ex: 946, 316)");
    input = Console.ReadLine();
    Console.WriteLine();
    if (input == null)
    {
        Console.WriteLine("Invalid input");
        return;
    }
}
var questionNumbers = input!.Split(',').Select(d => d.Trim().PadLeft(4, '0'));
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
