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
    [Migration("20180418124151_MyFirstMigration324534587876665234234")]
    partial class MyFirstMigration324534587876665234234
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfSamurai.Battle", b =>
                {
                    b.Property<int>("ID");

                    b.Property<int?>("BattlelogID");

                    b.Property<bool>("Brutal");

                    b.Property<DateTime>("End");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Start");

                    b.HasKey("ID");

                    b.HasIndex("BattlelogID")
                        .IsUnique()
                        .HasFilter("[BattlelogID] IS NOT NULL");

                    b.ToTable("Battle");
                });

            modelBuilder.Entity("EfSamurai.Battledescription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Event");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Battledescription");
                });

            modelBuilder.Entity("EfSamurai.Battlelog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Time");

                    b.HasKey("ID");

                    b.ToTable("Battlelog");
                });

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SamuraiID");

                    b.Property<string>("Text");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("SamuraiID");

                    b.ToTable("Quote");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Hairstyle");

                    b.Property<string>("Name");

                    b.Property<string>("SamuraiInfoName");

                    b.Property<string>("SamuraiInfoRealName");

                    b.HasKey("ID");

                    b.HasIndex("SamuraiInfoName", "SamuraiInfoRealName");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("EfSamurai.SamuraiBattle", b =>
                {
                    b.Property<int>("BattleID");

                    b.Property<int>("SamuraiID");

                    b.HasKey("BattleID", "SamuraiID");

                    b.HasIndex("SamuraiID");

                    b.ToTable("SamuraiBattle");
                });

            modelBuilder.Entity("EfSamurai.SamuraiInfo", b =>
                {
                    b.Property<string>("Name");

                    b.Property<string>("RealName");

                    b.Property<string>("BattleNames");

                    b.HasKey("Name", "RealName");

                    b.ToTable("SamuraiInfo");
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
                        .WithOne("Battle")
                        .HasForeignKey("EfSamurai.Battle", "BattlelogID");

                    b.HasOne("EfSamurai.Battledescription", "Battledescription")
                        .WithOne("Battle")
                        .HasForeignKey("EfSamurai.Battle", "ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EfSamurai.Quote", b =>
                {
                    b.HasOne("EfSamurai.Samurai")
                        .WithMany("Quote")
                        .HasForeignKey("SamuraiID");
                });

            modelBuilder.Entity("EfSamurai.Samurai", b =>
                {
                    b.HasOne("EfSamurai.SamuraiInfo", "SamuraiInfo")
                        .WithMany()
                        .HasForeignKey("SamuraiInfoName", "SamuraiInfoRealName");
                });

            modelBuilder.Entity("EfSamurai.SamuraiBattle", b =>
                {
                    b.HasOne("EfSamurai.Battle", "Battle")
                        .WithMany("SamuraisBattles")
                        .HasForeignKey("BattleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EfSamurai.Samurai", "Samurai")
                        .WithMany("SamuraisBattles")
                        .HasForeignKey("SamuraiID")
                        .OnDelete(DeleteBehavior.Cascade);
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
