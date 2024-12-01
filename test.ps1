if (-not $args[0] -or -not $args[0] -match '^\d+$') {
    Write-Host "Please provide a valid day number as argument"
    exit
}

$paddedDay  = "{0:D2}" -f $args[0]
dotnet test --filter Day$paddedDay