
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode22;

namespace AdventOfCode22.Tests;

[TestClass]
public class Day01Test
{
    private string input1 = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    [TestMethod]
    public void Part1()
    {
        int want = 24000;
        Assert.AreEqual(want, Day01.Part1(input1));
    }

    [TestMethod]
    public void Part2()
    {
        int want = 45000;
        Assert.AreEqual(want, Day01.Part2(input1));
    }
}
