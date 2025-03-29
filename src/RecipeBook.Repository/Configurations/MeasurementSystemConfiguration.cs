using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Configurations;

internal sealed class MeasurementSystemConfiguration : IEntityTypeConfiguration<MeasurementSystemEntity>
{
    public void Configure(EntityTypeBuilder<MeasurementSystemEntity> builder)
    {
        builder.HasKey(measurementSystem => measurementSystem.Id);

        builder.Property(measurementSystem => measurementSystem.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}