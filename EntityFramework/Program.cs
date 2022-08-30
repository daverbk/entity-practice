using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var factory = new CookbookContextFactory();

await EntityStates(factory);
await ChangeTracking(factory);
await AttachEntities(factory);
await NoTracking(factory);
await RawSql(factory);
await Transactions(factory);
await ExpressionTree(factory);

static async Task EntityStates(CookbookContextFactory factory)
{
    await using var dbContext = factory.CreateDbContext();
    
    var newDish = new Dish {
        Title = "Foo",
        Notes = "Bar"
    };

    var state = dbContext.Entry(newDish).State; // << Detached

    dbContext.Dishes.Add(newDish);
    state = dbContext.Entry(newDish).State; // << Added 

    await dbContext.SaveChangesAsync(); 
    state = dbContext.Entry(newDish).State; // << Unchanged

    newDish.Notes = "Baz";
    state = dbContext.Entry(newDish).State; // << Modified

    dbContext.Dishes.Remove(newDish);
    state = dbContext.Entry(newDish).State; // << Deleted

    await dbContext.SaveChangesAsync();
    state = dbContext.Entry(newDish).State; // << Detached
}

static async Task ChangeTracking(CookbookContextFactory factory)
{
    await using var dbContext = factory.CreateDbContext();
    
    var newDish = new Dish {
        Title = "Foo",
        Notes = "Bar"
    };
    
    dbContext.Dishes.Add(newDish);
    await dbContext.SaveChangesAsync(); 
    newDish.Notes = "Baz";

    var entry = dbContext.Entry(newDish);

    var originalValue = entry.OriginalValues[nameof(Dish.Notes)]!.ToString();
    var dishFromDatabase = await dbContext.Dishes.SingleAsync(d => d.Id == newDish.Id);

    await using var dbContext2 = factory.CreateDbContext();
    var dishFromDatabase2 = await dbContext2.Dishes.SingleAsync(d => d.Id == newDish.Id);
}

static async Task AttachEntities(CookbookContextFactory factory)
{
    await using var dbContext = factory.CreateDbContext();
    
    var newDish = new Dish {
        Title = "Foo",
        Notes = "Bar"
    };
    
    dbContext.Dishes.Add(newDish);
    await dbContext.SaveChangesAsync();
    
    // EF: Forget the "newDish" object
    dbContext.Entry(newDish).State = EntityState.Detached;
    var state = dbContext.Entry(newDish).State;

    dbContext.Dishes.Update(newDish);
    await dbContext.SaveChangesAsync();
}

static async Task NoTracking(CookbookContextFactory factory)
{
    using var dbContext = factory.CreateDbContext();

    // SELECT * FROM Dishes
    var dishes = await dbContext.Dishes.AsNoTracking().ToArrayAsync();
    var state = dbContext.Entry(dishes[0]).State;
}

static async Task RawSql(CookbookContextFactory factory)
{
    await using var dbContext = factory.CreateDbContext();

    var dishes = await dbContext.Dishes
        .FromSqlRaw("SELECT * FROM Dishes")
        .ToArrayAsync();
    
    var filter = "%z";
    dishes = await dbContext.Dishes
        .FromSqlInterpolated($"SELECT * FROM Dishes WHERE Notes LIKE {filter}")
        .ToArrayAsync();

    // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD 
    // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD 
    // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD 
    // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD 
    // SQL Injection 
    dishes = await dbContext.Dishes
        .FromSqlRaw("SELECT * FROM Dishes WHERE Notes LIKE '" + filter + "'")
        .ToArrayAsync();

    await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM Dishes WHERE Id NOT IN (SELECT DishId FROM Ingredients)");
}

static async Task Transactions(CookbookContextFactory factory)
{
    await using var dbContext = factory.CreateDbContext();

    await using var transaction = await dbContext.Database.BeginTransactionAsync();

    try
    {
        dbContext.Dishes.Add(new Dish { Title = "Foo", Notes = "Bar" });
        await dbContext.SaveChangesAsync();

        await dbContext.Database.ExecuteSqlRawAsync("SELECT 1/0 as Bad");
        await transaction.CommitAsync();
    }
    catch (SqlException ex)
    {
        Debug.WriteLine($"Something bad happened: {ex.Message}");
    }
}

static async Task ExpressionTree(CookbookContextFactory factory)
{
    await using var dbContext = factory.CreateDbContext();
    var newDish = new Dish { Title = "Foo", Notes = "Bar" };
    dbContext.Dishes.Add(newDish);
    await dbContext.SaveChangesAsync();

    var dishes = await dbContext.Dishes
        .Where(d => d.Title.StartsWith("F"))
        .ToArrayAsync();

    Func<Dish, bool> f = d => d.Title.StartsWith("F");
    Expression<Func<Dish, bool>> ex = d => d.Title.StartsWith("F");

    var inMemoryDishes = new[]
    {
        new Dish { Title = "Foo", Notes = "Bar" },
        new Dish { Title = "Foo", Notes = "Bar" }
    };

    dishes = inMemoryDishes
        .Where(d => d.Title.StartsWith("F"))
        .ToArray();
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
    public DbSet<Dish> Dishes { get; set; } = null!;

    public DbSet<DishIngredient> Ingredients { get; set; } = null!;

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
            .UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]!);

        return new CookbookContext(optionsBuilder.Options);
    }
}
