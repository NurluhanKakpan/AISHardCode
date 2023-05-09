﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using techTask2.Data;

#nullable disable

namespace techTask2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("techTask2.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AppStatus")
                        .HasColumnType("text");

                    b.Property<DateTime>("AppTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AppType")
                        .HasColumnType("text");

                    b.Property<bool>("InProcess")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsAccept")
                        .HasColumnType("boolean");

                    b.Property<string>("OwnerAddress")
                        .HasColumnType("text");

                    b.Property<string>("OwnerFirstName")
                        .HasColumnType("text");

                    b.Property<string>("OwnerFullName")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<string>("OwnerIin")
                        .HasColumnType("text");

                    b.Property<string>("OwnerLastName")
                        .HasColumnType("text");

                    b.Property<string>("OwnerRegion")
                        .HasColumnType("text");

                    b.Property<string>("Psc")
                        .HasColumnType("text");

                    b.Property<string>("TransportCategory")
                        .HasColumnType("text");

                    b.Property<string>("TransportGrnz")
                        .HasColumnType("text");

                    b.Property<int>("TransportId")
                        .HasColumnType("integer");

                    b.Property<string>("TransportMarca")
                        .HasColumnType("text");

                    b.Property<string>("TransportVin")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TransportId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("techTask2.Models.Inspector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Iin")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Inspectors");
                });

            modelBuilder.Entity("techTask2.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MessageForOwner")
                        .HasColumnType("text");

                    b.Property<DateTime>("MessageTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("techTask2.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Iin")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("techTask2.Models.Srts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("OwnerFullName")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<string>("OwnerIin")
                        .HasColumnType("text");

                    b.Property<string>("OwnerRegion")
                        .HasColumnType("text");

                    b.Property<bool>("Sign")
                        .HasColumnType("boolean");

                    b.Property<string>("SrtsNumber")
                        .HasColumnType("text");

                    b.Property<string>("TransportCategory")
                        .HasColumnType("text");

                    b.Property<string>("TransportGrnz")
                        .HasColumnType("text");

                    b.Property<int>("TransportId")
                        .HasColumnType("integer");

                    b.Property<string>("TransportMarca")
                        .HasColumnType("text");

                    b.Property<string>("TransportVin")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TransportId")
                        .IsUnique();

                    b.ToTable("Srts");
                });

            modelBuilder.Entity("techTask2.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Grnz")
                        .HasColumnType("text");

                    b.Property<bool>("HaveSrts")
                        .HasColumnType("boolean");

                    b.Property<string>("Marca")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<string>("Vin")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("techTask2.Models.Application", b =>
                {
                    b.HasOne("techTask2.Models.Owner", "Owner")
                        .WithMany("Applications")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("techTask2.Models.Transport", "Transport")
                        .WithMany("Applications")
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("techTask2.Models.Message", b =>
                {
                    b.HasOne("techTask2.Models.Owner", "Owner")
                        .WithMany("Messages")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("techTask2.Models.Srts", b =>
                {
                    b.HasOne("techTask2.Models.Owner", "Owner")
                        .WithMany("OwnerSrts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("techTask2.Models.Transport", "Transport")
                        .WithOne("Srts")
                        .HasForeignKey("techTask2.Models.Srts", "TransportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("techTask2.Models.Transport", b =>
                {
                    b.HasOne("techTask2.Models.Owner", "Owner")
                        .WithMany("Transports")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("techTask2.Models.Owner", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Messages");

                    b.Navigation("OwnerSrts");

                    b.Navigation("Transports");
                });

            modelBuilder.Entity("techTask2.Models.Transport", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Srts");
                });
#pragma warning restore 612, 618
        }
    }
}
