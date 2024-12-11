namespace ReboteqTask.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderDetailConfiguration());
        builder.ApplyConfiguration(new CouponConfiguration());

        // Apply all configurations from assembly
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Add seed data
        SeedData(builder);

        base.OnModelCreating(builder);
    }

    private void SeedData(ModelBuilder builder)
    {
        // Seed Categories
        var categoryIds = 1;
        var categoryFaker = new Faker<Category>()
            .RuleFor(c => c.Id, f => categoryIds++)
            .RuleFor(c => c.Name, f => f.Commerce.Categories(1).First());

        var categories = categoryFaker.Generate(8);
        builder.Entity<Category>().HasData(categories);

        // Seed Products
        var productIds = 1;
        var productFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => productIds++)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Photo, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Price, f => f.Finance.Amount(10, 1000, 2))
            .RuleFor(p => p.CategoryId, f => f.PickRandom(categories.Select(c => c.Id)));

        var products = productFaker.Generate(100);
        builder.Entity<Product>().HasData(products);

        // Seed Coupons
        var couponIds = 1;
        var couponFaker = new Faker<Coupon>()
            .RuleFor(c => c.Id, f => couponIds++)
            .RuleFor(c => c.Code, f => $"COUPON-{f.Random.AlphaNumeric(6).ToUpper()}")
            .RuleFor(c => c.Discount, f => f.Random.Decimal(5, 30));

        var coupons = couponFaker.Generate(10);
        builder.Entity<Coupon>().HasData(coupons);
    }
}
