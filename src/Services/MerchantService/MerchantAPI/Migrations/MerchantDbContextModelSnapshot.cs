﻿// <auto-generated />
using System;
using GB_Project.Services.MerchantService.MerchantInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MerchantAPI.Migrations
{
    [DbContext(typeof(MerchantDbContext))]
    partial class MerchantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel.MerchantBasic", b =>
                {
                    b.Property<Guid>("AuthPkId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("AuthPkId");

                    b.ToTable("MerchantBasic","merchant");
                });

            modelBuilder.Entity("GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel.MerchantIdentity", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AvailableSatartTime")
                        .HasColumnType("date");

                    b.Property<DateTime>("AvailableTime")
                        .HasColumnType("date");

                    b.Property<string>("IdentityImgB")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("IdentityImgF")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("IdentityName")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("IdentityNum")
                        .HasColumnType("varchar(18)");

                    b.Property<string>("LicenseCode")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("LicenseImg")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LicenseName")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LicenseOwner")
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("MShopId");

                    b.Property<string>("Tel")
                        .HasColumnType("varchar(11)");

                    b.HasKey("PkId");

                    b.ToTable("MerchantIdentity","merchant");
                });

            modelBuilder.Entity("GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel.MerchantShop", b =>
                {
                    b.Property<Guid>("MBasicId");

                    b.Property<Guid>("ShopId");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MIdentityId");

                    b.HasKey("MBasicId", "ShopId");

                    b.HasIndex("MIdentityId")
                        .IsUnique()
                        .HasFilter("[MIdentityId] IS NOT NULL");

                    b.ToTable("MerchantShops","merchant");
                });

            modelBuilder.Entity("GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel.MerchantShop", b =>
                {
                    b.HasOne("GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel.MerchantBasic", "MBasic")
                        .WithMany("Shops")
                        .HasForeignKey("MBasicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel.MerchantIdentity", "MIdentity")
                        .WithOne("MShop")
                        .HasForeignKey("GB_Project.Services.MerchantService.MerchantDomin.AggregatesModel.MerchantShop", "MIdentityId");
                });
#pragma warning restore 612, 618
        }
    }
}
