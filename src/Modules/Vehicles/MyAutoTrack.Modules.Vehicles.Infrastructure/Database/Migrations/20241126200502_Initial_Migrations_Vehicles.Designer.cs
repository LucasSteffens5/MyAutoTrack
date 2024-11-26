﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAutoTrack.Modules.Vehicles.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Database.Migrations
{
    [DbContext(typeof(VehiclesDbContext))]
    [Migration("20241126200502_Initial_Migrations_Vehicles")]
    partial class Initial_Migrations_Vehicles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("vehicles")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyAutoTrack.Modules.Vehicles.Domain.Manufacturers.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_manufacturer");

                    b.ToTable("manufacturer", "vehicles");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Vehicles.Domain.Owners.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_owner");

                    b.ToTable("owner", "vehicles");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Vehicles.Domain.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("FabricationYear")
                        .HasColumnType("integer")
                        .HasColumnName("fabrication_year");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("license_plate");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uuid")
                        .HasColumnName("manufacturer_id");

                    b.Property<long>("Mileage")
                        .HasColumnType("bigint")
                        .HasColumnName("mileage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.HasKey("Id")
                        .HasName("pk_vehicles");

                    b.HasIndex("ManufacturerId")
                        .HasDatabaseName("ix_vehicles_manufacturer_id");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_vehicles_owner_id");

                    b.ToTable("vehicles", "vehicles");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Vehicles.Domain.Vehicles.Vehicle", b =>
                {
                    b.HasOne("MyAutoTrack.Modules.Vehicles.Domain.Manufacturers.Manufacturer", null)
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vehicles_manufacturer_manufacturer_id");

                    b.HasOne("MyAutoTrack.Modules.Vehicles.Domain.Owners.Owner", null)
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_vehicles_owner_owner_id");
                });
#pragma warning restore 612, 618
        }
    }
}
