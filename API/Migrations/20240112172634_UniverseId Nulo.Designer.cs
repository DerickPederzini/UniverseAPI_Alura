﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(UniverseContext))]
    [Migration("20240112172634_UniverseId Nulo")]
    partial class UniverseIdNulo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MyProperty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("API.Models.Celestial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EmitsLight")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Mass")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("CelestialBodies");
                });

            modelBuilder.Entity("API.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CelestialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CelestialId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("API.Models.Telescope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("CelestialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("CelestialId");

                    b.ToTable("Telescopes");
                });

            modelBuilder.Entity("API.Models.Celestial", b =>
                {
                    b.HasOne("API.Models.Address", "Address")
                        .WithOne("Celestial")
                        .HasForeignKey("API.Models.Celestial", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("API.Models.Session", b =>
                {
                    b.HasOne("API.Models.Celestial", "Celestial")
                        .WithMany("Session")
                        .HasForeignKey("CelestialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Celestial");
                });

            modelBuilder.Entity("API.Models.Telescope", b =>
                {
                    b.HasOne("API.Models.Address", "address")
                        .WithOne("Telescope")
                        .HasForeignKey("API.Models.Telescope", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Celestial", "Celestial")
                        .WithMany("Telescope")
                        .HasForeignKey("CelestialId");

                    b.Navigation("Celestial");

                    b.Navigation("address");
                });

            modelBuilder.Entity("API.Models.Address", b =>
                {
                    b.Navigation("Celestial")
                        .IsRequired();

                    b.Navigation("Telescope")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Models.Celestial", b =>
                {
                    b.Navigation("Session");

                    b.Navigation("Telescope");
                });
#pragma warning restore 612, 618
        }
    }
}
