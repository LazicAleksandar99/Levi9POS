﻿// <auto-generated />
using System;
using Levi9.POS.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Levi9.POS.Domain.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Levi9.POS.Domain.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastUpdate")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1.maja, Derventa",
                            Email = "marko@gmail.com",
                            GlobalId = new Guid("2a602f8e-e6fe-4229-8914-a676e1c752c2"),
                            LastUpdate = "133277539861042731",
                            Name = "Marko",
                            Phone = "+387 65 132 527"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Koste Racina 24, Novi Sad",
                            Email = "aleksa@gmail.com",
                            GlobalId = new Guid("17742107-890a-492d-9ce3-dd4eb0b51f34"),
                            LastUpdate = "133277539861042758",
                            Name = "Aleksa",
                            Phone = "+387 64 862 476"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Strumicka 13, Novi Sad",
                            Email = "milos@gmail.com",
                            GlobalId = new Guid("0166e73d-befa-47ab-a81b-29571c2778c6"),
                            LastUpdate = "133277539861042795",
                            Name = "Milos",
                            Phone = "+387 65 912 127"
                        });
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("CreationDay")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("DocumetType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastUpdate")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            CreationDay = "133277539861042842",
                            DocumetType = "INVOICE",
                            GlobalId = new Guid("ce8d01a7-ea56-49df-bd07-9d6977307aa8"),
                            LastUpdate = "133277539861042858"
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 2,
                            CreationDay = "133277539861042887",
                            DocumetType = "INVOICE",
                            GlobalId = new Guid("2dc086ad-581b-4eb5-91dc-097d0911c74d"),
                            LastUpdate = "133277539861042899"
                        },
                        new
                        {
                            Id = 3,
                            ClientId = 3,
                            CreationDay = "133277539861042915",
                            DocumetType = "INVOICE",
                            GlobalId = new Guid("c163bd84-b871-4ff2-a79b-746c405e6a25"),
                            LastUpdate = "133277539861042928"
                        });
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<Guid>("GlobalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastUpdate")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQuantity = 30,
                            GlobalId = new Guid("a2eb5681-3d85-4bd5-9435-1cb1038b3912"),
                            LastUpdate = "133277539861042364",
                            Name = "Levi 9 T-Shirt",
                            Price = 10f,
                            ProductImageUrl = "baseURL//nekiurl1.png"
                        },
                        new
                        {
                            Id = 2,
                            AvailableQuantity = 10,
                            GlobalId = new Guid("5890b251-f854-44e6-b172-e190b2f13032"),
                            LastUpdate = "133277539861042474",
                            Name = "Novis T-Shirt",
                            Price = 15f,
                            ProductImageUrl = "baseURL//nekiurl2.png"
                        },
                        new
                        {
                            Id = 3,
                            AvailableQuantity = 20,
                            GlobalId = new Guid("3846a52f-f5f9-44ab-bd24-3c6797889405"),
                            LastUpdate = "133277539861042492",
                            Name = "Vega IT T-Shirt",
                            Price = 20f,
                            ProductImageUrl = "baseURL//nekiurl3.png"
                        });
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.ProductDocument", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.ToTable("ProductDocuments");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            DocumentId = 1,
                            Currency = "RSD",
                            Price = 1200f,
                            Quantity = 20
                        },
                        new
                        {
                            ProductId = 2,
                            DocumentId = 2,
                            Currency = "EUR",
                            Price = 10f,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 3,
                            DocumentId = 3,
                            Currency = "USD",
                            Price = 15f,
                            Quantity = 15
                        });
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.Document", b =>
                {
                    b.HasOne("Levi9.POS.Domain.Models.Client", "Client")
                        .WithMany("Documents")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.ProductDocument", b =>
                {
                    b.HasOne("Levi9.POS.Domain.Models.Document", "Document")
                        .WithMany("ProductDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Levi9.POS.Domain.Models.Product", "Product")
                        .WithMany("ProductDocuments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.Client", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.Document", b =>
                {
                    b.Navigation("ProductDocuments");
                });

            modelBuilder.Entity("Levi9.POS.Domain.Models.Product", b =>
                {
                    b.Navigation("ProductDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}
