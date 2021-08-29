﻿// <auto-generated />
using System;
using Fruit.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fruit.Data.Migrations
{
    [DbContext(typeof(FruitShoppingDbContext))]
    [Migration("20210829164543_AlterTableFruitPicture")]
    partial class AlterTableFruitPicture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fruit.Domain.Entities.FruitEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId")
                        .IsUnique();

                    b.ToTable("Fruit");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.FruitInventoryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FruitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FruitInventory");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.FruitPictureEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FruitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FruitId");

                    b.ToTable("FruitPicture");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.Sell.CartEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.Sell.CartItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FruitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.FruitEntity", b =>
                {
                    b.HasOne("Fruit.Domain.Entities.FruitInventoryEntity", "Inventory")
                        .WithOne("Fruit")
                        .HasForeignKey("Fruit.Domain.Entities.FruitEntity", "InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.FruitPictureEntity", b =>
                {
                    b.HasOne("Fruit.Domain.Entities.FruitEntity", "Fruit")
                        .WithMany("Pictures")
                        .HasForeignKey("FruitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fruit");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.Sell.CartItemEntity", b =>
                {
                    b.HasOne("Fruit.Domain.Entities.FruitEntity", "Fruit")
                        .WithMany("SellItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fruit.Domain.Entities.Sell.CartEntity", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Fruit");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.FruitEntity", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("SellItems");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.FruitInventoryEntity", b =>
                {
                    b.Navigation("Fruit");
                });

            modelBuilder.Entity("Fruit.Domain.Entities.Sell.CartEntity", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
