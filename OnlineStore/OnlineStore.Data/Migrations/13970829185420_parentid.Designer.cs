﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineStore.Data;

namespace OnlineStore.Data.Migrations
{
    [DbContext(typeof(OnlineStoreContext))]
    [Migration("13970829185420_parentid")]
    partial class parentid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineStore.Data.Entities.Brand", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("NameFa");

                    b.HasKey("ID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryParentID");

                    b.Property<string>("Name");

                    b.Property<string>("NameFa");

                    b.HasKey("ID");

                    b.HasIndex("CategoryParentID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.CategoryProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<int>("ProductID");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProductID");

                    b.ToTable("CategoryProducts");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderNumber");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.OrderItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<int?>("OrderID");

                    b.Property<long>("Price");

                    b.Property<int>("ProductID");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandID");

                    b.Property<string>("Name");

                    b.Property<string>("NameFa");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.ProductConfig", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color");

                    b.Property<string>("Guaranty");

                    b.Property<int>("ProductID");

                    b.Property<int>("SellerID");

                    b.Property<string>("Size");

                    b.HasKey("ID");

                    b.HasIndex("ProductID");

                    b.HasIndex("SellerID");

                    b.ToTable("ProductConfigs");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.Seller", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.Category", b =>
                {
                    b.HasOne("OnlineStore.Data.Entities.Category", "CategoryParent")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryParentID");
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.CategoryProduct", b =>
                {
                    b.HasOne("OnlineStore.Data.Entities.Category", "Category")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineStore.Data.Entities.Product", "Product")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.OrderItem", b =>
                {
                    b.HasOne("OnlineStore.Data.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID");

                    b.HasOne("OnlineStore.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.Product", b =>
                {
                    b.HasOne("OnlineStore.Data.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OnlineStore.Data.Entities.ProductConfig", b =>
                {
                    b.HasOne("OnlineStore.Data.Entities.Product", "Product")
                        .WithMany("ProductConfigs")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OnlineStore.Data.Entities.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
