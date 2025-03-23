using Microsoft.EntityFrameworkCore;
using RecipeBook.Repository.Entities;
using System;

namespace RecipeBook.Repository;

public class RecipeBookContext : DbContext
{
    public DbSet<RecipeEntity> Recipe { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<ImagesEntity> Image { get; set; }
    public DbSet<IngredientsEntity> Ingredient { get; set; }
    public DbSet<MeasurementSystemEntity> MeasurementSystem { get; set; }
    public DbSet<UnitOfMeasurementEntity> UnitOfMeasurement { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Databases/RecipeBook.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeBookContext).Assembly);
}