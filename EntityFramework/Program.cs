using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var factory = new CookbookContextFactory();

await using var context = factory.CreateDbContext(args);
{
    Console.WriteLine("Add Porridge");
    
    var porridge = new Dish
    {
        Title = "Porridge",
        Notes = "This is a great dish",
        Starts = 4
    };

    context.Dishes.Add(porridge);
    await context.SaveChangesAsync();
    
    Console.WriteLine($"Added Porridge (id = {porridge.Id}) successfully");

    Console.WriteLine("Checking stars for Porridge");
    var dishes = await context.Dishes.Where(dish => dish.Title.Contains("Porridge")).ToListAsync();

    if (dishes.Count == 1)
    {
        Console.WriteLine("Found some dishes!");
    }
    
    Console.WriteLine("Change porridge stars for 5");
    porridge.Starts = 5;
    await context.SaveChangesAsync();
    Console.WriteLine("Changed stars");
    
    Console.WriteLine("Removing porridge");
    context.Dishes.Remove(porridge);
    await context.SaveChangesAsync();
    Console.WriteLine("Porridge removed");
}

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

class CookbookContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }

    public DbSet<DishIngredient> Ingredients { get; set; }

    public CookbookContext(DbContextOptions<CookbookContext> options) : base(options)
    { }
}

class CookbookContextFactory : IDesignTimeDbContextFactory<CookbookContext>
{
    public CookbookContext CreateDbContext(string[]? args = null)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        var optionsBuilder = new DbContextOptionsBuilder<CookbookContext>();
        optionsBuilder
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

        return new CookbookContext(optionsBuilder.Options);
    }
}


