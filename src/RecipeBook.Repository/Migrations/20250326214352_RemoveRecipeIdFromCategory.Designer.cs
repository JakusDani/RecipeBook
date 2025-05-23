﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeBook.Repository;

#nullable disable

namespace RecipeBook.Repository.Migrations
{
    [DbContext(typeof(RecipeBookContext))]
    [Migration("20250326214352_RemoveRecipeIdFromCategory")]
    partial class RemoveRecipeIdFromCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("RecipeBook.Repository.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.ImagesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.IngredientsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitOfMeasurementId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UnitOfMeasurementId");

                    b.ToTable("Ingredients", (string)null);
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.MeasurementSystemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitOfMeasurementId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MeasurementSystem");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.RecipeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Instruction")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("MainImageLink")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("PortionPerPerson")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipe", (string)null);
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.UnitOfMeasurementEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("MeasurementSystemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementSystemId");

                    b.ToTable("UnitOfMeasurement", (string)null);
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.ImagesEntity", b =>
                {
                    b.HasOne("RecipeBook.Repository.Entities.RecipeEntity", "Recipe")
                        .WithMany("Images")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.IngredientsEntity", b =>
                {
                    b.HasOne("RecipeBook.Repository.Entities.RecipeEntity", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeBook.Repository.Entities.UnitOfMeasurementEntity", "UnitOfMeasurement")
                        .WithMany("Ingredients")
                        .HasForeignKey("UnitOfMeasurementId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("UnitOfMeasurement");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.RecipeEntity", b =>
                {
                    b.HasOne("RecipeBook.Repository.Entities.CategoryEntity", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.UnitOfMeasurementEntity", b =>
                {
                    b.HasOne("RecipeBook.Repository.Entities.MeasurementSystemEntity", "MeasurementSystem")
                        .WithMany("UnitOfMeasurements")
                        .HasForeignKey("MeasurementSystemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MeasurementSystem");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.MeasurementSystemEntity", b =>
                {
                    b.Navigation("UnitOfMeasurements");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.RecipeEntity", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("RecipeBook.Repository.Entities.UnitOfMeasurementEntity", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
