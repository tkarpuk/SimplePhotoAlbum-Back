﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SimplePhotoAlbum.DAL;

namespace SimplePhotoAlbum_Back.Migrations
{
    [DbContext(typeof(ApplicationDb))]
    [Migration("20211115101123_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SimplePhotoAlbum.DAL.Entities.PhotoImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("ImageType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("InfoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InfoId")
                        .IsUnique();

                    b.ToTable("images");
                });

            modelBuilder.Entity("SimplePhotoAlbum.DAL.Entities.PhotoInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("photos");
                });

            modelBuilder.Entity("SimplePhotoAlbum.DAL.Entities.PhotoImage", b =>
                {
                    b.HasOne("SimplePhotoAlbum.DAL.Entities.PhotoInfo", "Info")
                        .WithOne("Image")
                        .HasForeignKey("SimplePhotoAlbum.DAL.Entities.PhotoImage", "InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Info");
                });

            modelBuilder.Entity("SimplePhotoAlbum.DAL.Entities.PhotoInfo", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}