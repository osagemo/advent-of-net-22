
namespace AdventOfCode22;

public static class Day01
{
    public static int Part1(string input)
    {
        var caloriesPerElf = GetCaloriesPerElf(input);

        return caloriesPerElf.Last();
    }

    public static int Part2(string input)
    {
        var caloriesPerElf = GetCaloriesPerElf(input);

        int total = 0;
        foreach (var calories in caloriesPerElf)
        {
            total += calories;
        }

        return total;
    }

    private static IEnumerable<int> GetCaloriesPerElf(string input)
    {
        var caloriesPerElf = new List<int>();
        var lines = input.Split("\r\n");

        int currentTotal = 0;
        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                caloriesPerElf.Add(currentTotal);
                currentTotal = 0;
                continue;
            }

            currentTotal += int.Parse(line);
        }

        caloriesPerElf.Sort();
        return caloriesPerElf;
    }
}
