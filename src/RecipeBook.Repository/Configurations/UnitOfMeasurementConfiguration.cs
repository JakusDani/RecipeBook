﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeBook.Repository.Entities;

namespace RecipeBook.Repository.Configurations;

internal sealed class UnitOfMeasurementConfiguration : IEntityTypeConfiguration<UnitOfMeasurementEntity>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasurementEntity> builder)
    {
        builder.ToTable("UnitOfMeasurement");

        builder.HasKey(unit => unit.Id);

        builder.Property(unit => unit.Id);
        builder.Property(unit => unit.Name).IsRequired().HasMaxLength(50);

        builder.HasOne(unit => unit.MeasurementSystem)
            .WithMany(system => system.UnitOfMeasurements)
            .HasForeignKey(unit => unit.MeasurementSystemId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}