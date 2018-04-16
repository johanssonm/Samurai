﻿// <auto-generated />
using EfSamurai;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EfSamurai.Data.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    [Migration("20180416121416_Addedquoteid")]
    partial class Addedquoteid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ID");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("QuoteID");

                    b.HasKey("ID");

                    b.HasIndex("QuoteID");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.HasOne("EfSamurai.Quote", "Quote")
                        .WithMany()
                        .HasForeignKey("QuoteID");
                });
#pragma warning restore 612, 618
        }
    }
}