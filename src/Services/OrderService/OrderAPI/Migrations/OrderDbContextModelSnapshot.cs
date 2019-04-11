﻿// <auto-generated />
using System;
using GB_Project.Services.OrderService.OrderInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OrderAPI.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GB_Project.Services.OrderService.OrderDomin.GroupOrderAggregate.GroupBuyingOrder", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CpkId")
                        .HasColumnType("Uniqueidentifier");

                    b.Property<string>("Evaluate")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("GroupProductName")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Img")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("OrderCode")
                        .HasColumnType("Uniqueidentifier");

                    b.Property<int>("PayWay")
                        .HasColumnType("int");

                    b.Property<string>("SName")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("date");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.HasKey("PkId");

                    b.ToTable("GroupBuyingOrder","order");
                });
#pragma warning restore 612, 618
        }
    }
}
