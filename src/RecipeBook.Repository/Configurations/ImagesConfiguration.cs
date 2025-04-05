using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Configurations;

internal sealed class ImagesConfiguration : IEntityTypeConfiguration<ImagesEntity>
{
    public void Configure(EntityTypeBuilder<ImagesEntity> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(image => image.Id);

        builder.Property(image => image.Id).ValueGeneratedOnAdd();
        builder.Property(image => image.Name).IsRequired().HasMaxLength(100);
        builder.Property(image => image.ImageLink).IsRequired().HasMaxLength(200);

        builder.HasOne(image => image.Recipe)
            .WithMany(recipe => recipe.Images)
            .HasForeignKey(image => image.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}