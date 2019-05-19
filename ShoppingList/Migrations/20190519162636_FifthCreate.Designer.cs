﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingList.DBContext;

namespace ShoppingList.Migrations
{
    [DbContext(typeof(ShoppingListContext))]
    [Migration("20190519162636_FifthCreate")]
    partial class FifthCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingList.Models.BuyList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Creator");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("Id");

                    b.ToTable("BuyList");
                });

            modelBuilder.Entity("ShoppingList.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<int>("UnitPrice");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ShoppingList.Models.FoodCounter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuyListId");

                    b.Property<int>("Counter");

                    b.Property<int>("FoodId");

                    b.Property<DateTime>("Modification")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 5, 19, 18, 26, 36, 47, DateTimeKind.Local));

                    b.HasKey("Id");

                    b.HasIndex("BuyListId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodCounters");
                });

            modelBuilder.Entity("ShoppingList.Models.Messages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodId");

                    b.Property<int>("Rating");

                    b.Property<string>("Text")
                        .HasMaxLength(1000);

                    b.Property<DateTime>("creation");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ShoppingList.Models.FoodCounter", b =>
                {
                    b.HasOne("ShoppingList.Models.BuyList", "BuyList")
                        .WithMany("shoppingList")
                        .HasForeignKey("BuyListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoppingList.Models.Food", "Foods")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingList.Models.Messages", b =>
                {
                    b.HasOne("ShoppingList.Models.Food", "Foods")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}