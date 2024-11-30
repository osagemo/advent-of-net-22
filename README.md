# Advent of Code in .NET

This project bootstraps Advent of Code solutions in .NET.
It was originally created as a PoC for a discussion at $WORK.

## Project Structure

- **DayGenerator**: Utility to generate boilerplate code for each day's challenge.
- **AdventOfCode22**: Contains solutions for each day's challenge.
- **AdventOfCode22.Tests**: Contains unit tests for each day's solutions.

## Usage

### Generate Files for a New Day

By default, the `generate.ps1` script will create a DayXX folder in `AdventOfCode22`, with the boilerplate DayXX.cs and input file, as well as a DayXXTest file in `AdventOfCode22.Tests`

```powershell
.\generate.ps1 1

# from project
dotnet run <day> [rootdir] [testrootdir]
```

### Run the tests:

```powershell
.\test.ps1 1

# all tests
dotnet test

# single test
dotnet test --filter Day01
```

### Run the solutions with input:

```powershell
.\run.ps1 1

# from project
dotnet run 1
```
