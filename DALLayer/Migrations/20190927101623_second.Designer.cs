﻿// <auto-generated />
using System;
using DALLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DALLayer.Migrations
{
    [DbContext(typeof(DBModel))]
    [Migration("20190927101623_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModels.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID");

                    b.Property<int>("PID");

                    b.Property<int>("Quantity");

                    b.Property<double>("TotalPrice");

                    b.Property<double>("UnitPrice");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerID");

                    b.HasIndex("PID");

                    b.ToTable("T_Cart");
                });

            modelBuilder.Entity("DomainModels.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("T_Category");
                });

            modelBuilder.Entity("DomainModels.Customers", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MobileNo")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("T_Customers");
                });

            modelBuilder.Entity("DomainModels.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<double>("Price");

                    b.Property<int>("ProductID");

                    b.Property<string>("Quantity")
                        .IsRequired();

                    b.Property<double>("TotalPrice");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductID");

                    b.ToTable("T_Orders");
                });

            modelBuilder.Entity("DomainModels.PaymentDetails", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount");

                    b.Property<DateTime>("PayDate");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("PaymentId");

                    b.ToTable("T_PaymentDetails");
                });

            modelBuilder.Entity("DomainModels.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategId");

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("Image");

                    b.Property<double>("Price");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.Property<int?>("Quantity")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("CategId");

                    b.ToTable("T_Products");
                });

            modelBuilder.Entity("DomainModels.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnName("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("T_Roles");
                });

            modelBuilder.Entity("DomainModels.Cart", b =>
                {
                    b.HasOne("DomainModels.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModels.Products", "Products")
                        .WithMany()
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModels.Customers", b =>
                {
                    b.HasOne("DomainModels.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModels.Orders", b =>
                {
                    b.HasOne("DomainModels.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DomainModels.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModels.Products", b =>
                {
                    b.HasOne("DomainModels.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("CategId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
