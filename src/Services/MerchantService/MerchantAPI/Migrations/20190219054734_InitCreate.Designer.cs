﻿// <auto-generated />
using System;
using GB_project.Services.MerchantService.MerchantInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MerchantAPI.Migrations
{
    [DbContext(typeof(MerchantDbContext))]
    [Migration("20190219054734_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GB_project.Services.MerchantService.MerchantDomin.Aggregateroot.MerchantBasic", b =>
                {
                    b.Property<Guid>("AuthPkId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IdentityPkId");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AuthPkId");

                    b.HasIndex("IdentityPkId");

                    b.ToTable("MerchantBasic","merchant");
                });

            modelBuilder.Entity("GB_project.Services.MerchantService.MerchantDomin.Aggregateroot.MerchantIdentity", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableSatartTime")
                        .HasColumnType("date");

                    b.Property<DateTime>("AvailableTime")
                        .HasColumnType("date");

                    b.Property<string>("IdentityImgB")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IdentityImgF")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("IdentityName")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("IdentityNum")
                        .HasColumnType("varchar(18)");

                    b.Property<string>("LicenseCode")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("LicenseImg")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LicenseName")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LicenseOwner")
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("MerchantId");

                    b.Property<string>("Tel")
                        .HasColumnType("varchar(11)");

                    b.HasKey("PkId");

                    b.ToTable("MerchantIdentity","merchant");
                });

            modelBuilder.Entity("GB_project.Services.MerchantService.MerchantDomin.Aggregateroot.MerchantBasic", b =>
                {
                    b.HasOne("GB_project.Services.MerchantService.MerchantDomin.Aggregateroot.MerchantIdentity", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityPkId");
                });
#pragma warning restore 612, 618
        }
    }
}
