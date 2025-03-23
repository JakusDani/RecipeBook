using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Configurations;

internal sealed class IngredientsConfiguration : IEntityTypeConfiguration<IngredientsEntity>
{
    public void Configure(EntityTypeBuilder<IngredientsEntity> builder)
    {
        builder.ToTable("Ingredients");
        builder.HasKey(ingredient => ingredient.Id);

        builder.Property(ingredient => ingredient.Id).ValueGeneratedOnAdd();
        builder.Property(ingredient => ingredient.Name).IsRequired().HasMaxLength(100);
        builder.Property(ingredient => ingredient.Quantity).IsRequired();
        builder.Property(ingredient => ingredient.UnitOfMeasurementId).IsRequired();

        builder.HasOne(ingredient => ingredient.Recipe)
            .WithMany(recipe => recipe.Ingredients)
            .HasForeignKey(ingredient => ingredient.RecipeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(ingredient => ingredient.UnitOfMeasurement)
            .WithMany(unitOfMeasurement => unitOfMeasurement.Ingredients)
            .HasForeignKey(ingredient => ingredient.UnitOfMeasurementId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}