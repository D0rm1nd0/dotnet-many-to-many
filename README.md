dotnet add package MySql.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet ef migrations add InitialCreate

dotnet aspnet-codegenerator controller -name HeroController -async -api -m Hero -dc RelationContext -outDir Controllers 