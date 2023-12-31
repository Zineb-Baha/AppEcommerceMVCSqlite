﻿// <auto-generated />
using AmazonCloneMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmazonCloneMVC.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("AmazonCloneMVC.Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomCategorie")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategorieID");

                    b.ToTable("CATEGORIES");
                });

            modelBuilder.Entity("AmazonCloneMVC.Models.Produit", b =>
                {
                    b.Property<int>("ProduitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategorieID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Prix")
                        .HasColumnType("REAL");

                    b.Property<string>("ProduitName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantite")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProduitID");

                    b.HasIndex("CategorieID");

                    b.ToTable("PRODUITS");
                });

            modelBuilder.Entity("AmazonCloneMVC.Models.Produit", b =>
                {
                    b.HasOne("AmazonCloneMVC.Models.Categorie", "Categorie")
                        .WithMany("Produits")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("AmazonCloneMVC.Models.Categorie", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
