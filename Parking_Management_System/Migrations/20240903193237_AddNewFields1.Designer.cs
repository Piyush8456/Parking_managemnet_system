﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking_Management_System.Models;

#nullable disable

namespace Parking_Management_System.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240903193237_AddNewFields1")]
    partial class AddNewFields1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parking_Management_System.Models.ParkingLots", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableSpaces")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SelectedSpaceSize")
                        .HasColumnType("int");

                    b.Property<int>("SpaceSize")
                        .HasColumnType("int");

                    b.Property<int>("TotalCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("parkingLots");
                });

            modelBuilder.Entity("Parking_Management_System.Models.ParkingSpace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("SpaceSize")
                        .HasColumnType("int");

                    b.Property<int>("parkingLotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("parkingLotId");

                    b.ToTable("parkingSpaces");
                });

            modelBuilder.Entity("Parking_Management_System.Models.ParkingTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Duration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExitTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParkingSpaceId")
                        .HasColumnType("int");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSpaceId");

                    b.HasIndex("VehicleId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("ParkingTransactions");
                });

            modelBuilder.Entity("Parking_Management_System.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LicensePlateNumber")
                        .HasColumnType("int");

                    b.Property<string>("OwnerContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Parking_Management_System.Models.ParkingSpace", b =>
                {
                    b.HasOne("Parking_Management_System.Models.ParkingLots", "ParkingLot")
                        .WithMany("ParkingSpaces")
                        .HasForeignKey("parkingLotId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ParkingLot");
                });

            modelBuilder.Entity("Parking_Management_System.Models.ParkingTransaction", b =>
                {
                    b.HasOne("Parking_Management_System.Models.ParkingSpace", "ParkingSpaces")
                        .WithMany("ParkingTransactions")
                        .HasForeignKey("ParkingSpaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Parking_Management_System.Models.Vehicle", "Vehicle")
                        .WithMany("ParkingTransactions")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Parking_Management_System.Models.Vehicle", "Vehicles")
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpaces");

                    b.Navigation("Vehicle");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Parking_Management_System.Models.ParkingLots", b =>
                {
                    b.Navigation("ParkingSpaces");
                });

            modelBuilder.Entity("Parking_Management_System.Models.ParkingSpace", b =>
                {
                    b.Navigation("ParkingTransactions");
                });

            modelBuilder.Entity("Parking_Management_System.Models.Vehicle", b =>
                {
                    b.Navigation("ParkingTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
