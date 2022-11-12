﻿// <auto-generated />
using Demo.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo.Migrations
{
    [DbContext(typeof(CarDetailsDbContext))]
    partial class CarDetailsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo.Models.CarDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("brand")
                        .HasColumnType("int");

                    b.Property<string>("carName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("modal")
                        .HasColumnType("int");

                    b.Property<int>("newcar")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("cardetails");
                });

            modelBuilder.Entity("Demo.Models.login", b =>
                {
                    b.Property<string>("emailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("emailId");

                    b.ToTable("logins");
                });
#pragma warning restore 612, 618
        }
    }
}
