﻿// <auto-generated />
using System;
using GB_Project.Services.ManagerService.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagerService.Migrations
{
    [DbContext(typeof(ManagerDbContext))]
    [Migration("20190426132849_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GB_Project.Services.ManagerService.Models.AggregateRoot.ViolateUser", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsInBlackMenu")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWarned")
                        .HasColumnType("bit");

                    b.Property<Guid>("ManagerId")
                        .HasColumnType("Uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("PkId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("violateUser","manager");
                });
#pragma warning restore 612, 618
        }
    }
}