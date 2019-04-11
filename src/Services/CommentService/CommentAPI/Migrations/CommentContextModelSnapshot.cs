﻿// <auto-generated />
using System;
using GB_Project.Services.CommentService.CommentInfrastructrue.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CommentAPI.Migrations
{
    [DbContext(typeof(CommentContext))]
    partial class CommentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GB_Project.Services.CommentService.CommentDomin.AggregateModel.ReplyComment", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CommentId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Reply")
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PkId");

                    b.HasIndex("CommentId");

                    b.ToTable("ReplyComment","comment");
                });

            modelBuilder.Entity("GB_Project.Services.CommentService.CommentDomin.AggregateModel.UserComment", b =>
                {
                    b.Property<Guid>("PkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Img")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PkId");

                    b.ToTable("UserComment","comment");
                });

            modelBuilder.Entity("GB_Project.Services.CommentService.CommentDomin.AggregateModel.ReplyComment", b =>
                {
                    b.HasOne("GB_Project.Services.CommentService.CommentDomin.AggregateModel.UserComment", "Comment")
                        .WithMany()
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
