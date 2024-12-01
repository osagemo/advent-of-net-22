if (-not $args[0] -or -not $args[0] -match '^\d+$') {
    Write-Host "Please provide a valid day number as argument"
    exit
}

dotnet run --project ./DayGenerator $args[0] ./AdventOfCode22 ./AdventOfCode22.Tests