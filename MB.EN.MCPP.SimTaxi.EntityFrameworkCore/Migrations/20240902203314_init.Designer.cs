﻿// <auto-generated />
using System;
using MB.EN.MCPP.SimTaxi.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MB.EN.MCPP.SimTaxi.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240902203314_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingPassenger", b =>
                {
                    b.Property<int>("BookingsId")
                        .HasColumnType("int");

                    b.Property<int>("PassengersId")
                        .HasColumnType("int");

                    b.HasKey("BookingsId", "PassengersId");

                    b.HasIndex("PassengersId");

                    b.ToTable("BookingPassenger");
                });

            modelBuilder.Entity("MB.EN.MCPP.SimTaxi.Entities.Bookings.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CarId")
                        .HasColumnType("int");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("MB.EN.MCPP.SimTaxi.Entities.Cars.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PowerType")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MB.EN.MCPP.SimTaxi.Entities.Drivers.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("MB.EN.MCPP.SimTaxi.Entities.Passengers.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("BookingPassenger", b =>
                {
                    b.HasOne("MB.EN.MCPP.SimTaxi.Entities.Bookings.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MB.EN.MCPP.SimTaxi.Entities.Passengers.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MB.EN.MCPP.SimTaxi.Entities.Bookings.Booking", b =>
                {
                    b.HasOne("MB.EN.MCPP.SimTaxi.Entities.Cars.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("MB.EN.MCPP.SimTaxi.Entities.Drivers.Driver", "Driver")
                        .WithMany("Bookings")
                        .HasForeignKey("DriverId");

                    b.Navigation("Car");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("MB.EN.MCPP.SimTaxi.Entities.Cars.Car", b =>
                {
                    b.HasOne("MB.EN.MCPP.SimTaxi.Entities.Drivers.Driver", "Driver")
                        .WithMany("Cars")
                        .HasForeignKey("DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("MB.EN.MCPP.SimTaxi.Entities.Drivers.Driver", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
