if (-not $args[0] -or -not $args[0] -match '^\d+$') {
    Write-Host "Please provide a valid day number as argument"
    exit
}
dotnet run --project ./AdventOfCode22 $args[0] 