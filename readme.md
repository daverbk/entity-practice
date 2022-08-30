# Entity Framework start flow

## 1. Create models 
**Models represent database tables**

```csharp
    class Dish
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public int? Starts { get; set; }

        public List<DishIngredient> Ingredients { get; set; } = new();
    }

    class DishIngredient
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;
    
        [MaxLength(50)]
        public string UnitOfMeasure { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Amount { get; set; }

        public Dish? Dish { get; set; }

        public int DishId { get; set; }
    }
```

## 2. Create a db context 
**Represents connection string with db**

```csharp
    class CookbookContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; } = null!;

        public DbSet<DishIngredient> Ingredients { get; set; } = null!;

        public CookbookContext(DbContextOptions<CookbookContext> options) : base(options)
        { }
    }
```

# 3. Create a db context factory
**We can use `appsettings.json` for the purposes of storing connection data**

```csharp
    class CookbookContextFactory : IDesignTimeDbContextFactory<CookbookContext>
    {
        public CookbookContext CreateDbContext(string[]? args = null)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var optionsBuilder = new DbContextOptionsBuilder<CookbookContext>();
            optionsBuilder
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]!);

            return new CookbookContext(optionsBuilder.Options);
        }
    }
```

`appsettings.json` **file**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CookbookLesson;User=sa;Password=***"
  }
}
```

## 4. Install ef globally on your machine 

`dotnet tool install --global dotnet-ef`

## 5. Migrations

**Migrations are needed to transfer data from C# to a database table.**
**From solution directory run `dotnet ef migrations add Initial` to add initial migration that will be responsible for converting C# instances to db table records.**

**To finally create a db run `dotnet ef database update`**

## **_NuGet packages to be installed:_** 

`Microsoft.EntityFrameworkCore.SqlServer`

`Microsoft.Extensions.Configuration.Json`

`Microsoft.EntityFrameworkCore.Design`

`Microsoft.Extensions.Logging.Console`
