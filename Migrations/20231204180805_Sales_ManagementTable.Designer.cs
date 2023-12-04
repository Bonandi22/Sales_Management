﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales_Management.Context;

#nullable disable

namespace Sales_Management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231204180805_Sales_ManagementTable")]
    partial class Sales_ManagementTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sales_Management.Models.ClientModel", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Sales_Management.Models.LoginModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Sales_Management.Models.ProductModel", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Sales_Management.Models.SaleItem", b =>
                {
                    b.Property<int?>("SaleId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("SaleId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("Sales_Management.Models.SalesModel", b =>
                {
                    b.Property<int>("SalesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductModelProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SalesDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("SalesmanId")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("SalesId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductModelProductId");

                    b.HasIndex("SalesmanId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Sales_Management.Models.SalesmanModel", b =>
                {
                    b.Property<int>("SalesmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cellphone")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("SalesmanId");

                    b.ToTable("Salesmen");
                });

            modelBuilder.Entity("Sales_Management.Models.SaleItem", b =>
                {
                    b.HasOne("Sales_Management.Models.ProductModel", "Product")
                        .WithMany("SaleItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales_Management.Models.SalesModel", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Sales_Management.Models.SalesModel", b =>
                {
                    b.HasOne("Sales_Management.Models.ClientModel", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientId");

                    b.HasOne("Sales_Management.Models.ProductModel", null)
                        .WithMany("Sales")
                        .HasForeignKey("ProductModelProductId");

                    b.HasOne("Sales_Management.Models.SalesmanModel", "Salesman")
                        .WithMany("Sales")
                        .HasForeignKey("SalesmanId");

                    b.Navigation("Client");

                    b.Navigation("Salesman");
                });

            modelBuilder.Entity("Sales_Management.Models.ClientModel", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Sales_Management.Models.ProductModel", b =>
                {
                    b.Navigation("SaleItems");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Sales_Management.Models.SalesModel", b =>
                {
                    b.Navigation("SaleItems");
                });

            modelBuilder.Entity("Sales_Management.Models.SalesmanModel", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
