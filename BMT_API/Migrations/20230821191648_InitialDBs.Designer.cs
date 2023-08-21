﻿// <auto-generated />
using BMT_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BMT_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230821191648_InitialDBs")]
    partial class InitialDBs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.5.22302.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BMT_API.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "ABC Company",
                            Email = "johndoe@abc.com",
                            Firstname = "John",
                            Lastname = "Doe",
                            Mobile = "099824788822"
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "ABC Company",
                            Email = "janedoe@abc.com",
                            Firstname = "Jane",
                            Lastname = "Doe",
                            Mobile = "099924781211"
                        },
                        new
                        {
                            Id = 3,
                            CompanyName = "JDC Company",
                            Email = "juandelacruz@jdc.com",
                            Firstname = "Juan",
                            Lastname = "Dela Cruz",
                            Mobile = "099824781111"
                        });
                });

            modelBuilder.Entity("BMT_API.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocalUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            Password = "admin123",
                            Role = "admin",
                            UserName = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}