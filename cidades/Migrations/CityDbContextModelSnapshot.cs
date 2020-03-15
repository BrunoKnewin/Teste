﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cidades.Infrastructure;

namespace cidades.Migrations
{
    [DbContext(typeof(CityDbContext))]
    partial class CityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("cidades.Model.City", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryState")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Population")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name", "CountryState")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("cidades.Model.CityToCity", b =>
                {
                    b.Property<int>("IdCity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdCityTo")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdCity", "IdCityTo");

                    b.HasIndex("IdCityTo");

                    b.ToTable("CityToCity");
                });

            modelBuilder.Entity("cidades.Model.CityToCity", b =>
                {
                    b.HasOne("cidades.Model.City", "City")
                        .WithMany("CityRoutes")
                        .HasForeignKey("IdCity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cidades.Model.City", "CityTo")
                        .WithMany("CityRoutesFrom")
                        .HasForeignKey("IdCityTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
