﻿// <auto-generated />
using System;
using BiddingService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BiddingService.Data.Migrations
{
    [DbContext(typeof(BiddingDbContext))]
    partial class BiddingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BiddingService.Aircraft", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BiddingId")
                        .HasColumnType("uuid");

                    b.Property<int>("BuildDate")
                        .HasColumnType("integer");

                    b.Property<string>("Colour")
                        .HasColumnType("text");

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<int>("Milage")
                        .HasColumnType("integer");

                    b.Property<string>("ModelNo")
                        .HasColumnType("text");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BiddingId")
                        .IsUnique();

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("BiddingService.Models.Bidding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("AmountSold")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BiddingEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CurrentTopBid")
                        .HasColumnType("integer");

                    b.Property<int>("ReservePrice")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Vendor")
                        .HasColumnType("text");

                    b.Property<string>("WinningBidder")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Biddings");
                });

            modelBuilder.Entity("BiddingService.Aircraft", b =>
                {
                    b.HasOne("BiddingService.Models.Bidding", "Bidding")
                        .WithOne("Aircraft")
                        .HasForeignKey("BiddingService.Aircraft", "BiddingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bidding");
                });

            modelBuilder.Entity("BiddingService.Models.Bidding", b =>
                {
                    b.Navigation("Aircraft");
                });
#pragma warning restore 612, 618
        }
    }
}