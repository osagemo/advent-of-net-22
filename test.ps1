$paddedDay  = "{0:D2}" -f $args[0]
dotnet test --filter Day$paddedDay