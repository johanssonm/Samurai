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
    [Migration("20180416131746_Addedbattleevents")]
    partial class Addedbattleevents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfSamurai.Battle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BattlelogID");

                    b.Property<bool>("Brutal");

                    b.Property<DateTime>("End");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Start");

                    b.HasKey("ID");

                    b.HasIndex("BattlelogID");

                    b.ToTable("Battle");
                });

            modelBuilder.Entity("EfSamurai.Battledescription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Battledescription");
                });

            modelBuilder.Entity("EfSamurai.Battlelog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BattledescriptionID");

                    b.Property<DateTime>("Time");

                    b.HasKey("ID");

                    b.HasIndex("BattledescriptionID");

                    b.ToTable("Battlelog");
                });

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Hairstyle");

                    b.Property<string>("Name");

                    b.Property<int?>("QuoteID");

                    b.HasKey("ID");

                    b.HasIndex("QuoteID");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EfSamurai.SamuraisBattles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BattleID");

                    b.Property<int?>("SamuraiID");

                    b.HasKey("ID");

                    b.HasIndex("BattleID");

                    b.HasIndex("SamuraiID");

                    b.ToTable("SamuraisBattles");
                });

            modelBuilder.Entity("EfSamurai.SecretIdentity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("SamuraiID");

                    b.HasKey("ID");

                    b.HasIndex("SamuraiID")
                        .IsUnique();

                    b.ToTable("SecretIdentity");
                });

            modelBuilder.Entity("EfSamurai.Battle", b =>
                {
                    b.HasOne("EfSamurai.Battlelog", "Battlelog")
                        .WithMany()
                        .HasForeignKey("BattlelogID");
                });

            modelBuilder.Entity("EfSamurai.Battlelog", b =>
                {
                    b.HasOne("EfSamurai.Battledescription", "Battledescription")
                        .WithMany()
                        .HasForeignKey("BattledescriptionID");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.HasOne("EfSamurai.Quote", "Quote")
                        .WithMany()
                        .HasForeignKey("QuoteID");
                });

            modelBuilder.Entity("EfSamurai.SamuraisBattles", b =>
                {
                    b.HasOne("EfSamurai.Battle", "Battle")
                        .WithMany("SamuraisBattles")
                        .HasForeignKey("BattleID");

                    b.HasOne("EfSamurai.Samurai", "Samurai")
                        .WithMany("SamuraisBattles")
                        .HasForeignKey("SamuraiID");
                });

            modelBuilder.Entity("EfSamurai.SecretIdentity", b =>
                {
                    b.HasOne("EfSamurai.Samurai")
                        .WithOne("Identity")
                        .HasForeignKey("EfSamurai.SecretIdentity", "SamuraiID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
