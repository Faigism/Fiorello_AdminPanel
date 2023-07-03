﻿// <auto-generated />
using System;
using Fiorello_AdminPanel.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiorello_AdminPanel.Migrations
{
    [DbContext(typeof(FiorelloDbContext))]
    [Migration("20230701132759_SliderUpdateTable")]
    partial class SliderUpdateTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.Flower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("SKU")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Flowers");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.FlowerCategory", b =>
                {
                    b.Property<int>("FlowerId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("FlowerId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("FlowerCategories");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.FlowerImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FlowerId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FlowerId");

                    b.ToTable("FlowerImages");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.FlowerTag", b =>
                {
                    b.Property<int>("FlowerId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("FlowerId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("FlowerTags");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BtnTxt")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Title1")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.FlowerCategory", b =>
                {
                    b.HasOne("Fiorello_AdminPanel.Entities.Category", null)
                        .WithMany("flowerCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiorello_AdminPanel.Entities.Flower", null)
                        .WithMany("flowerCategories")
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.FlowerImage", b =>
                {
                    b.HasOne("Fiorello_AdminPanel.Entities.Flower", null)
                        .WithMany("flowerImages")
                        .HasForeignKey("FlowerId");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.FlowerTag", b =>
                {
                    b.HasOne("Fiorello_AdminPanel.Entities.Flower", null)
                        .WithMany("flowerTags")
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiorello_AdminPanel.Entities.Tag", null)
                        .WithMany("flowerTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.Category", b =>
                {
                    b.Navigation("flowerCategories");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.Flower", b =>
                {
                    b.Navigation("flowerCategories");

                    b.Navigation("flowerImages");

                    b.Navigation("flowerTags");
                });

            modelBuilder.Entity("Fiorello_AdminPanel.Entities.Tag", b =>
                {
                    b.Navigation("flowerTags");
                });
#pragma warning restore 612, 618
        }
    }
}
