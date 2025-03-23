using Microsoft.EntityFrameworkCore;
using RecipeBook.Repository.Entities;
using System;

namespace RecipeBook.Repository;

public class RecipeBookContext : DbContext
{
    public DbSet<RecipeEntity> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=Databases/RecipeBook.db");
}