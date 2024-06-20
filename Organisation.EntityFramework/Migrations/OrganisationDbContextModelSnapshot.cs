﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Organisation.EntityFramework;

namespace Organisation.EntityFramework.Migrations
{
    [DbContext(typeof(OrganisationDbContext))]
    partial class OrganisationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Organisation.Domain.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("JobEndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobLength")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("JobStartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MachineNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalProduction")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Organisation.Domain.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MachineImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("MachineName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MachineNumber")
                        .HasMaxLength(8)
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductionSpeed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Organisation.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
