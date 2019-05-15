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
    [Migration("20190514202154_SecondCreate")]
    partial class SecondCreate
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

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("Id");

                    b.ToTable("BuyList");
                });

            modelBuilder.Entity("ShoppingList.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShoppingList.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<int>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ShoppingList.Models.FoodCounter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BuyListId");

                    b.Property<int>("Counter");

                    b.Property<int?>("FoodsId");

                    b.Property<int?>("FridgeListId");

                    b.Property<DateTime>("Modification");

                    b.HasKey("Id");

                    b.HasIndex("BuyListId");

                    b.HasIndex("FoodsId");

                    b.HasIndex("FridgeListId");

                    b.ToTable("FoodCounters");
                });

            modelBuilder.Entity("ShoppingList.Models.FridgeList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate");

                    b.HasKey("Id");

                    b.ToTable("FridgeList");
                });

            modelBuilder.Entity("ShoppingList.Models.Food", b =>
                {
                    b.HasOne("ShoppingList.Models.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingList.Models.FoodCounter", b =>
                {
                    b.HasOne("ShoppingList.Models.BuyList")
                        .WithMany("shoppingList")
                        .HasForeignKey("BuyListId");

                    b.HasOne("ShoppingList.Models.Food", "Foods")
                        .WithMany()
                        .HasForeignKey("FoodsId");

                    b.HasOne("ShoppingList.Models.FridgeList")
                        .WithMany("shoppingList")
                        .HasForeignKey("FridgeListId");
                });
#pragma warning restore 612, 618
        }
    }
}
