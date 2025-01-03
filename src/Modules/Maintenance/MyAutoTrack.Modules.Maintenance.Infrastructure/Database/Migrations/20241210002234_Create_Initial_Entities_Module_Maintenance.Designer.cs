﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAutoTrack.Modules.Maintenance.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyAutoTrack.Modules.Maintenance.Infrastructure.Database.Migrations
{
    [DbContext(typeof(MaintenanceDbContext))]
    [Migration("20241210002234_Create_Initial_Entities_Module_Maintenance")]
    partial class Create_Initial_Entities_Module_Maintenance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("maintenance")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<long>("Inventory")
                        .HasColumnType("bigint")
                        .HasColumnName("inventory");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_items");

                    b.ToTable("items", "maintenance");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndsAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ends_at_utc");

                    b.Property<long>("Mileage")
                        .HasColumnType("bigint")
                        .HasColumnName("mileage");

                    b.Property<DateTime>("StartsAtUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("starts_at_utc");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("total_price");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id")
                        .HasName("pk_maintenances");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_maintenances_vehicle_id");

                    b.ToTable("maintenances", "maintenance");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.MaintenanceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<Guid>("MaintenanceId")
                        .HasColumnType("uuid")
                        .HasColumnName("maintenance_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("price");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_maintenance_items");

                    b.HasIndex("ItemId")
                        .HasDatabaseName("ix_maintenance_items_item_id");

                    b.HasIndex("MaintenanceId")
                        .HasDatabaseName("ix_maintenance_items_maintenance_id");

                    b.ToTable("maintenance_items", "maintenance");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<int>("FabricationYear")
                        .HasColumnType("integer")
                        .HasColumnName("fabrication_year");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("license_plate");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uuid")
                        .HasColumnName("manufacturer_id");

                    b.Property<long>("Mileage")
                        .HasColumnType("bigint")
                        .HasColumnName("mileage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.HasKey("Id")
                        .HasName("pk_vehicles");

                    b.ToTable("vehicles", "maintenance");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Maintenance", b =>
                {
                    b.HasOne("MyAutoTrack.Modules.Maintenance.Domain.Vehicles.Vehicle", "Vehicle")
                        .WithMany("Maintenances")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_maintenances_vehicles_vehicle_id");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.MaintenanceItem", b =>
                {
                    b.HasOne("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Item", "Item")
                        .WithMany("MaintenanceItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_maintenance_items_items_item_id");

                    b.HasOne("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Maintenance", "Maintenance")
                        .WithMany("MaintenanceItems")
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_maintenance_items_maintenances_maintenance_id");

                    b.Navigation("Item");

                    b.Navigation("Maintenance");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Item", b =>
                {
                    b.Navigation("MaintenanceItems");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Maintenances.Maintenance", b =>
                {
                    b.Navigation("MaintenanceItems");
                });

            modelBuilder.Entity("MyAutoTrack.Modules.Maintenance.Domain.Vehicles.Vehicle", b =>
                {
                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}
