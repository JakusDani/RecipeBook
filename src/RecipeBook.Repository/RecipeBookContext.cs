using Microsoft.EntityFrameworkCore;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository;

public class RecipeBookContext : DbContext
{
    public DbSet<RecipeEntity> Recipe { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<ImagesEntity> Image { get; set; }
    public DbSet<IngredientsEntity> Ingredient { get; set; }
    public DbSet<MeasurementSystemEntity> MeasurementSystem { get; set; }
    public DbSet<UnitOfMeasurementEntity> UnitOfMeasurement { get; set; }

    public RecipeBookContext(DbContextOptions<RecipeBookContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeBookContext).Assembly);
}