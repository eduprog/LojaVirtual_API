﻿// <auto-generated />
using System;
using LojaVirtual.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaVirtual.Infra.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200423002104_CreateTableUsers")]
    partial class CreateTableUsers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LojaVirtual.Domain.Entities.Banner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<int>("Local")
                        .HasColumnType("int");

                    b.Property<int>("Pos")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(400)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserCreateId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserCreateId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.ProductSize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<Guid?>("UserCreateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserCreateId");

                    b.ToTable("ProductSizes");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.Banner", b =>
                {
                    b.HasOne("LojaVirtual.Domain.Entities.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.Category", b =>
                {
                    b.HasOne("LojaVirtual.Domain.Entities.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.Product", b =>
                {
                    b.HasOne("LojaVirtual.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("LojaVirtual.Domain.Entities.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("LojaVirtual.Domain.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");

                    b.HasOne("LojaVirtual.Domain.Entities.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");
                });

            modelBuilder.Entity("LojaVirtual.Domain.Entities.ProductSize", b =>
                {
                    b.HasOne("LojaVirtual.Domain.Entities.Product", "Product")
                        .WithMany("Sizes")
                        .HasForeignKey("ProductId");

                    b.HasOne("LojaVirtual.Domain.Entities.User", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId");
                });
#pragma warning restore 612, 618
        }
    }
}
