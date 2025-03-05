﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopApi.Context;

#nullable disable

namespace ShopApi.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopApi.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            Name = "Sony"
                        },
                        new
                        {
                            Id = new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            Name = "LG"
                        },
                        new
                        {
                            Id = new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            Name = "Huawei"
                        },
                        new
                        {
                            Id = new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            Name = "Xiaomi"
                        });
                });

            modelBuilder.Entity("ShopApi.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasAnnotation("Relational:JsonPropertyName", "lastName");

                    b.Property<int>("TCKN")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            Email = "tomakintomakin05@gmail.com",
                            FirstName = "Ömer",
                            LastName = "Tomakin",
                            TCKN = 231
                        },
                        new
                        {
                            Id = new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            Email = "ali.yilmaz@example.com",
                            FirstName = "Ali",
                            LastName = "Yılmaz",
                            TCKN = 234
                        },
                        new
                        {
                            Id = new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            Email = "ayse.kara@example.com",
                            FirstName = "Ayşe",
                            LastName = "Kara",
                            TCKN = 235
                        },
                        new
                        {
                            Id = new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            Email = "murat.demir@example.com",
                            FirstName = "Murat",
                            LastName = "Demir",
                            TCKN = 236
                        },
                        new
                        {
                            Id = new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            Email = "fatma.ozturk@example.com",
                            FirstName = "Fatma",
                            LastName = "Öztürk",
                            TCKN = 237
                        },
                        new
                        {
                            Id = new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            Email = "mehmet.celik@example.com",
                            FirstName = "Mehmet",
                            LastName = "Çelik",
                            TCKN = 238
                        });
                });

            modelBuilder.Entity("ShopApi.Models.CustomerDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("CustomerDetails", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0a58b50-92ad-41ea-bcfb-b227d29d4b9d"),
                            Address = "İstanbul, Türkiye",
                            Age = 30,
                            CustomerId = new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            Gender = true,
                            Job = "Yazılımcı"
                        },
                        new
                        {
                            Id = new Guid("b3e4bb49-3810-41c6-bb69-29b017bb1f13"),
                            Address = "Ankara, Türkiye",
                            Age = 28,
                            CustomerId = new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            Gender = true,
                            Job = "Mühendis"
                        },
                        new
                        {
                            Id = new Guid("c6a5478e-68f6-442b-9be6-3bafced1dbd6"),
                            Address = "İzmir, Türkiye",
                            Age = 25,
                            CustomerId = new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            Gender = false,
                            Job = "Öğrenci"
                        },
                        new
                        {
                            Id = new Guid("d93d0776-6d0c-44b4-b7e0-15b5d3b90a58"),
                            Address = "Bursa, Türkiye",
                            Age = 35,
                            CustomerId = new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            Gender = true,
                            Job = "Doktor"
                        },
                        new
                        {
                            Id = new Guid("e476b789-02f0-431e-8f88-8b0c358b29e1"),
                            Address = "Antalya, Türkiye",
                            Age = 40,
                            CustomerId = new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            Gender = false,
                            Job = "Avukat"
                        },
                        new
                        {
                            Id = new Guid("f9b0e460-7425-4b79-a94c-6659fdcb373b"),
                            Address = "Eskişehir, Türkiye",
                            Age = 32,
                            CustomerId = new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            Gender = true,
                            Job = "İşletmeci"
                        });
                });

            modelBuilder.Entity("ShopApi.Models.CustomersBrand", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("CustomerId", "BrandId");

                    b.HasIndex("BrandId");

                    b.ToTable("CustomerBrands", (string)null);

                    b.HasData(
                        new
                        {
                            CustomerId = new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            BrandId = new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CustomerId = new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            BrandId = new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CustomerId = new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            BrandId = new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CustomerId = new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            BrandId = new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CustomerId = new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            BrandId = new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CustomerId = new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            BrandId = new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            Id = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3f3a3f3-1f1f-4f1f-b1f1-8dbdd24dbd9c"),
                            BrandId = new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            CustomerId = new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"),
                            Description = "Apple's latest smartphone with a powerful A15 chip.",
                            Name = "iPhone 13",
                            Title = "Smartphone",
                            price = 999
                        },
                        new
                        {
                            Id = new Guid("b4f4b4f4-2f2f-4f2f-b2f2-9dbdd25dcf9d"),
                            BrandId = new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            CustomerId = new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"),
                            Description = "Samsung's flagship phone with advanced camera features.",
                            Name = "Samsung Galaxy S21",
                            Title = "Smartphone",
                            price = 899
                        },
                        new
                        {
                            Id = new Guid("c5f5c5f5-3f3f-5f3f-c3f3-0dbdd26dcf9e"),
                            BrandId = new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            CustomerId = new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"),
                            Description = "Sony's noise-canceling wireless headphones.",
                            Name = "Sony WH-1000XM4",
                            Title = "Headphones",
                            price = 350
                        },
                        new
                        {
                            Id = new Guid("d6f6d6f6-4f4f-6f4f-d4f4-1dbdd27ddf9f"),
                            BrandId = new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            CustomerId = new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"),
                            Description = "LG's 55-inch OLED television with stunning picture quality.",
                            Name = "LG OLED TV",
                            Title = "Television",
                            price = 1200
                        },
                        new
                        {
                            Id = new Guid("e7f7e7f7-5f5f-7f5f-e5f5-2dbdd28eea9f"),
                            BrandId = new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            CustomerId = new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"),
                            Description = "Huawei's premium laptop with a sleek design and powerful performance.",
                            Name = "Huawei MateBook X Pro",
                            Title = "Laptop",
                            price = 1500
                        },
                        new
                        {
                            Id = new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            BrandId = new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            CustomerId = new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"),
                            Description = "Xiaomi's fitness tracker with a full-screen AMOLED display.",
                            Name = "Xiaomi Mi Band 6",
                            Title = "Fitness Tracker",
                            price = 50
                        });
                });

            modelBuilder.Entity("ShopApi.Models.CustomerDetail", b =>
                {
                    b.HasOne("ShopApi.Models.Customer", "Customer")
                        .WithOne("CustomerDetail")
                        .HasForeignKey("ShopApi.Models.CustomerDetail", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopApi.Models.CustomersBrand", b =>
                {
                    b.HasOne("ShopApi.Models.Brand", "Brand")
                        .WithMany("CustomersBrands")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopApi.Models.Customer", "Customer")
                        .WithMany("CustomersBrands")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.HasOne("ShopApi.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ShopApi.Models.Customer", "Customer")
                        .WithMany("Products")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopApi.Models.Brand", b =>
                {
                    b.Navigation("CustomersBrands");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopApi.Models.Customer", b =>
                {
                    b.Navigation("CustomerDetail");

                    b.Navigation("CustomersBrands");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
