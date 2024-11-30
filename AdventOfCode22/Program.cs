using System.Diagnostics;
using System.Reflection;

class Program
{
    public static readonly string NameSpace = "AdventOfCode22";
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run <day number, e.g. 1>");
            return;
        }

        string dayNumber = args[0].ToLower();
        if (!int.TryParse(dayNumber, out _))
        {
            Console.WriteLine("Day must be a number.");
            return;
        }
        dayNumber = dayNumber.PadLeft(2, '0');
        string day = $"Day{dayNumber}";

        // Construct the expected namespace and class name (e.g., AdventOfCode.Day01)
        string namespaceAndClass = $"{NameSpace}.{day}";
        string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, day, "input.txt");

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Input file not found for {day}. Expected at: {inputFilePath}");
            return;
        }

        string input = File.ReadAllText(inputFilePath);

        try
        {
            // Load the specified class dynamically
            Type? dayType = Type.GetType(namespaceAndClass);
            if (dayType == null)
            {
                Console.WriteLine($"Class for {day} not found. Ensure the file and namespace are correct.");
                return;
            }

            // Invoke Part1 and Part2 methods dynamically
            MethodInfo? part1Method = dayType.GetMethod("Part1");
            MethodInfo? part2Method = dayType.GetMethod("Part2");

            if (part1Method == null || part2Method == null)
            {
                Console.WriteLine($"Methods Part1 or Part2 not found in class {namespaceAndClass}.");
                return;
            }
            var stopWatch = Stopwatch.StartNew();
            var result1 = part1Method.Invoke(null, new object[] { input });
            stopWatch.Stop();
            var time1 = stopWatch.Elapsed;
            stopWatch.Restart();
            var result2 = part2Method.Invoke(null, new object[] { input });
            stopWatch.Stop();

            Console.WriteLine($"{day} - Part 1: {result1} ({FormatTimeSpan(time1)})");
            Console.WriteLine($"{day} - Part 2: {result2} ({stopWatch.Elapsed.TotalMilliseconds}ms)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static string FormatTimeSpan(TimeSpan timeSpan)
    {
        if (timeSpan.TotalMinutes >= 1)
            return $"{timeSpan.TotalMinutes:F2} minutes";
        if (timeSpan.TotalSeconds >= 1)
            return $"{timeSpan.TotalSeconds:F2} seconds";
        return $"{timeSpan.TotalMilliseconds:F2} ms";
    }
}
public static class StringExtensions
{
    public static string FirstCharToUpper(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input[0].ToString().ToUpper() + input.Substring(1)
        };
}
