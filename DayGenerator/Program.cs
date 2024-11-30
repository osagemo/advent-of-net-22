using System;
using System.IO;
using System.Runtime.CompilerServices;

class DayGenerator
{
    private const string Namespace = "AdventOfCode22";

    static void Main(string[] args)
    {
        if (!ValidateArguments(args, out string dayNumber, out string rootDir, out string testRootDir))
        {
            return;
        }

        string dayFolder = Path.Combine(rootDir, $"Day{dayNumber.PadLeft(2, '0')}");
        string testDayFolder = testRootDir;
        // Create folder if not exists
        if (Directory.Exists(dayFolder))
        {
            Console.WriteLine($"Directory for Day {dayNumber} already exists.");
            return;
        }
        Directory.CreateDirectory(dayFolder);
        if (testRootDir == rootDir)
        {
            testRootDir = dayFolder;
        }

        string dayClassName = $"Day{dayNumber.PadLeft(2, '0')}";
        string dayClassContent = GetDayClassContent(dayClassName);
        string dayTestClassContent = GetDayTestClassContent(dayClassName);

        File.WriteAllText(Path.Combine(dayFolder, $"{dayClassName}.cs"), dayClassContent);
        File.WriteAllText(Path.Combine(testRootDir, $"{dayClassName}Test.cs"), dayTestClassContent);
        File.WriteAllText(Path.Combine(dayFolder, "input.txt"), "");
        Console.WriteLine($"Day {dayNumber} files created successfully.");
    }

    private static bool ValidateArguments(string[] args, out string dayNumber, out string rootDir, out string testRootDir)
    {
        dayNumber = "";
        rootDir = "";
        testRootDir = "";

        if (args.Length < 1 || args.Length > 3)
        {
            Console.WriteLine("Usage: dotnet run <day> [rootDir] [testRootDir]");
            return false;
        }

        dayNumber = args[0];
        if (!int.TryParse(dayNumber, out _))
        {
            Console.WriteLine("Day must be a number.");
            return false;
        }

        rootDir = args.Length > 1 ? args[1] : Directory.GetCurrentDirectory();
        if (!Directory.Exists(rootDir))
        {
            Console.WriteLine($"Invalid directory {rootDir}.");
            return false;
        }

        testRootDir = args.Length > 2 ? args[2] : Directory.GetCurrentDirectory();
        if (!Directory.Exists(testRootDir))
        {
            Console.WriteLine($"Invalid directory {testRootDir}.");
            return false;
        }

        return true;
    }

    private static string GetDayClassContent(string dayClassName)
    {
        return $@"
namespace {Namespace};

public static class {dayClassName}
{{
    public static int Part1(string input)
    {{
        
        return 0;
    }}

    public static int Part2(string input)
    {{
    
        return 0;
    }}
}}
";
    }

    private static string GetDayTestClassContent(string dayClassName)
    {
        return $@"
using Microsoft.VisualStudio.TestTools.UnitTesting;
using {Namespace};

namespace {Namespace}.Tests;

[TestClass]
public class {dayClassName}Test
{{
    private string input1 = @"""";

    [TestMethod]
    public void Part1()
    {{
        int want = -1;
        Assert.AreEqual(want, {dayClassName}.Part1(input1));
    }}  

    [TestMethod]
    public void Part2()
    {{
        int want = -1;
        Assert.AreEqual(want, {dayClassName}.Part2(input1));
    }}  
}}
";
    }
}
