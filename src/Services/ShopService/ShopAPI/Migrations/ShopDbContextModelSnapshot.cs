﻿// <auto-generated />
using System;
using GB_project.Services.ShopService.ShopInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ShopAPI.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBProduct", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Img")
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("OrinPrice")
                        .HasColumnType("smallmoney");

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VailEDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("VailSDate")
                        .HasColumnType("date");

                    b.Property<string>("VailTime")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PkId");

                    b.HasIndex("ShopId");

                    b.ToTable("GBProduct","shop");
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBProductItem", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GbItemImg");

                    b.Property<string>("GbItemName");

                    b.Property<int>("GbItemPrice");

                    b.Property<Guid>("GbProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PkId");

                    b.HasIndex("GbProductId");

                    b.ToTable("GBProductItem","shop");
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBRule", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("GBProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PkId");

                    b.HasIndex("GBProductId");

                    b.ToTable("GBRule","shop");
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.Product", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDisplay")
                        .HasColumnType("bit");

                    b.Property<short>("MSellNum")
                        .HasColumnType("smallint");

                    b.Property<short>("PraiseNum")
                        .HasColumnType("smallint");

                    b.Property<string>("ProductImg")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("smallmoney");

                    b.Property<Guid>("ProductType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopId");

                    b.HasKey("PkId");

                    b.HasIndex("ShopId");

                    b.ToTable("Product","shop");
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.ProductType", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PkId");

                    b.HasIndex("ShopId");

                    b.ToTable("ProductType","shop");
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.Shop", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("Manager");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Pic")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Tel")
                        .HasColumnType("varchar(11)");

                    b.Property<Guid>("Type")
                        .HasColumnType("Uniqueidentifier");

                    b.HasKey("PkId");

                    b.ToTable("shop","shop");
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.ShopMerchant", b =>
                {
                    b.Property<Guid>("MerchantId");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRegister")
                        .HasColumnType("bit");

                    b.HasKey("MerchantId", "ShopId");

                    b.HasIndex("ShopId");

                    b.ToTable("shopMerchant","shop");
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBProduct", b =>
                {
                    b.HasOne("GB_project.Services.ShopService.ShopDomin.AggregatesModel.Shop")
                        .WithMany("GbProduct")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBProductItem", b =>
                {
                    b.HasOne("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBProduct")
                        .WithMany("Items")
                        .HasForeignKey("GbProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBRule", b =>
                {
                    b.HasOne("GB_project.Services.ShopService.ShopDomin.AggregatesModel.GBProduct")
                        .WithMany("GbRule")
                        .HasForeignKey("GBProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.Product", b =>
                {
                    b.HasOne("GB_project.Services.ShopService.ShopDomin.AggregatesModel.Shop")
                        .WithMany("_product")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.ProductType", b =>
                {
                    b.HasOne("GB_project.Services.ShopService.ShopDomin.AggregatesModel.Shop")
                        .WithMany("_producttype")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GB_project.Services.ShopService.ShopDomin.AggregatesModel.ShopMerchant", b =>
                {
                    b.HasOne("GB_project.Services.ShopService.ShopDomin.AggregatesModel.Shop")
                        .WithMany("_shopmerchant")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
