﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutfitService.Data;

#nullable disable

namespace OutfitService.Data.Migrations
{
    [DbContext(typeof(OutfitContext))]
    [Migration("20241101070823_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("OutfitService.Models.Outfit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSeasonal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Occasion")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimesWorn")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Outfits");
                });
#pragma warning restore 612, 618
        }
    }
}
