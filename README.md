# Dotnet Many to Many

- dotnet ef o pode ser instalado como uma ferramenta global ou local. A maioria dos desenvolvedores prefere dotnet ef a instalação como uma ferramenta global usando o seguinte comando:

```bash
dotnet tool install --global dotnet-ef
```

```bash
dotnet add package MySql.EntityFrameworkCore

```

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

```

- Crie as models e os relacionamentos e defina as configurações do banco de dados e depois rode os seguintes comandos para criar as tabelas no banco de dados.

```bash
dotnet ef migrations add InitialCreate
```

```bash
dotnet ef database update
```

- Rode o comando a seguir para gerar controlers de api para a model `Hero`

```bash
dotnet aspnet-codegenerator controller -name HeroController -async -api -m Hero -dc RelationContext -outDir Controllers
```
