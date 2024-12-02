using System.Diagnostics;
using System.Reflection;

class Program
{
    public static readonly string NameSpace = "AdventOfCode22";
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: dotnet run <day number, e.g. 1, or 'all'>");
            return;
        }

        string dayArg = args[0].ToLower();

        if (dayArg == "all")
        {
            RunAllDays();
        }
        else
        {
            if (!int.TryParse(dayArg, out _))
            {
                Console.WriteLine("Day must be a number.");
                return;
            }
            dayArg = dayArg.PadLeft(2, '0');
            RunSingleDay(dayArg);
        }
    }

    private static void RunSingleDay(string dayNumber)
    {
        string day = $"Day{dayNumber}";
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
            Type? dayType = Type.GetType(namespaceAndClass);
            if (dayType == null)
            {
                Console.WriteLine($"Class for {day} not found. Ensure the file and namespace are correct.");
                return;
            }

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
            Console.WriteLine($"{day} - Part 2: {result2} ({FormatTimeSpan(stopWatch.Elapsed)})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static void RunAllDays()
    {
        Console.WriteLine("Running all days...");
        for (int i = 1; i <= 25; i++)
        {
            string dayNumber = i.ToString().PadLeft(2, '0');
            string day = $"Day{dayNumber}";
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, day, "input.txt");

            if (!File.Exists(inputFilePath))
            {
                continue;
            }
            Console.WriteLine($"\n--- Day {dayNumber} ---");
            RunSingleDay(dayNumber);
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
