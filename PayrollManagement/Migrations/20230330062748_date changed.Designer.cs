﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayrollManagement.EfData;

#nullable disable

namespace PayrollManagement.Migrations
{
    [DbContext(typeof(PaymentDbContext))]
    [Migration("20230330062748_date changed")]
    partial class datechanged
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PayrollManagement.Models.Salary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<double>("Bonus")
                        .HasColumnType("float");

                    b.Property<double>("CreditAmount")
                        .HasColumnType("float");

                    b.Property<string>("CreditDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Dues")
                        .HasColumnType("float");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<double>("Hometaken")
                        .HasColumnType("float");

                    b.Property<int>("PaymentID")
                        .HasColumnType("int");

                    b.Property<double>("SalaryPackage")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalEarnings")
                        .HasColumnType("float");

                    b.Property<double>("accountNumber")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("PaymentManagement");
                });
#pragma warning restore 612, 618
        }
    }
}
