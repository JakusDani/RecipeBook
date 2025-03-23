using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Configurations;

internal sealed class RecipeConfiguration : IEntityTypeConfiguration<RecipeEntity>
{
    public void Configure(EntityTypeBuilder<RecipeEntity> builder)
    {
        builder.ToTable("Recipe");

        builder.HasKey(recipe => recipe.Id);
        builder.Property(recipe => recipe.Id).ValueGeneratedOnAdd();

        builder.Property(recipe => recipe.Name).IsRequired().HasMaxLength(100);
        builder.Property(recipe => recipe.Description).HasMaxLength(500);
        builder.Property(recipe => recipe.MainImageLink).HasMaxLength(100);
        builder.Property(recipe => recipe.Instruction).HasMaxLength(2000);
        builder.Property(recipe => recipe.PortionPerPerson).IsRequired();

        builder.HasOne(recipe => recipe.Category)
            .WithMany(category => category.Recipes)
            .HasForeignKey(recipe => recipe.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(recipe => recipe.Ingredients)
            .WithOne(ingredient => ingredient.Recipe)
            .HasForeignKey(ingredient => ingredient.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(recipe => recipe.Images)
            .WithOne(image => image.Recipe)
            .HasForeignKey(image => image.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}