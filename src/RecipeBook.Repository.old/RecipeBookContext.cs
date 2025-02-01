using Microsoft.EntityFrameworkCore;
using RecipeBook.Repository.old.Entities;

namespace RecipeBook.Repository.old;

public class RecipeBookContext : DbContext
{
    public DbSet<RecipesEntity> Recipes { get; set; }
    public DbSet<CategoriesEntity> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // IConfigurationRoot configuration = new ConfigurationBuilder()
        //     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //     .AddJsonFile("appsettings.json")
        //     .Build();

        var connectionString = "server=localhost:3306;uid=root;pwd=;database=TestDb"; //configuration.GetConnectionString("BookDBConnection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Recipes
        modelBuilder.Entity<RecipesEntity>().ToTable("Recipes");
        modelBuilder.Entity<RecipesEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<RecipesEntity>().Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<RecipesEntity>().Property(x => x.Description).HasMaxLength(50);
        modelBuilder.Entity<RecipesEntity>().Property(x => x.Preparation)
            .HasMaxLength(1000)
            .IsRequired();
        modelBuilder.Entity<RecipesEntity>().Property(x => x.MainImageLink)
            .HasMaxLength(250)
            .IsRequired();
        
        modelBuilder.Entity<RecipesEntity>().HasOne(x => x.Category)
            .WithMany(x => x.Recipes)
            .HasForeignKey(x => x.CategoriesId);
        
        // Categories
        modelBuilder.Entity<CategoriesEntity>().ToTable("categories");
        modelBuilder.Entity<CategoriesEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<CategoriesEntity>().Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}