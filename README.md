# EFCorePossibleBug
EF Core possible bug reproduction mini project.

Prerequisites:
.NET 5.0

Project uses an SQLite database. If you wish to look inside it, I recommend downloading DB Browser for SQLite https://sqlitebrowser.org/dl/

Install using .NET CLI:  
`dotnet tool install --global dotnet-ef`  
`dotnet add package Microsoft.EntityFrameworkCore.Design`

Running the project:  
`dotnet run`

If you wish to inspect the empty Score object, put breakpoint in Program.cs line 24 and run the debugger.
