﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPortfolio.DataaccessLayer.Concrete;

#nullable disable

namespace MyPortfolio.DataaccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.ColdDrink", b =>
                {
                    b.Property<int>("ColdDrinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColdDrinkID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ColdDrinkDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColdDrinkImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColdDrinkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ColdDrinkPrice")
                        .HasColumnType("int");

                    b.HasKey("ColdDrinkID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ColdDrinks");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.Dessert", b =>
                {
                    b.Property<int>("DessertID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DessertID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("DessertDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DessertImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DessertName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DessertPrice")
                        .HasColumnType("int");

                    b.HasKey("DessertID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Desserts");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.Food", b =>
                {
                    b.Property<int>("FoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("FoodDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodPrice")
                        .HasColumnType("int");

                    b.HasKey("FoodID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.HotDrink", b =>
                {
                    b.Property<int>("HotDrinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotDrinkID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("HotDrinkDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotDrinkImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotDrinkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotDrinkPrice")
                        .HasColumnType("int");

                    b.HasKey("HotDrinkID");

                    b.HasIndex("CategoryID");

                    b.ToTable("HotDrinks");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.ColdDrink", b =>
                {
                    b.HasOne("MyPortfolio.EntityLayer.Concrete.Category", "Category")
                        .WithMany("ColdDrink")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.Dessert", b =>
                {
                    b.HasOne("MyPortfolio.EntityLayer.Concrete.Category", "Category")
                        .WithMany("Dessert")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.Food", b =>
                {
                    b.HasOne("MyPortfolio.EntityLayer.Concrete.Category", "Category")
                        .WithMany("Food")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.HotDrink", b =>
                {
                    b.HasOne("MyPortfolio.EntityLayer.Concrete.Category", "Category")
                        .WithMany("HotDrink")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MyPortfolio.EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("ColdDrink");

                    b.Navigation("Dessert");

                    b.Navigation("Food");

                    b.Navigation("HotDrink");
                });
#pragma warning restore 612, 618
        }
    }
}