using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(category => category.Id);

        builder.Property(category => category.Id);
        builder.Property(category => category.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(category => category.Recipes)
            .WithOne(recipe => recipe.Category)
            .HasForeignKey(recipe => recipe.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}