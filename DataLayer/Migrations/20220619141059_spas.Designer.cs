﻿// <auto-generated />
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(IzpitContext))]
    [Migration("20220619141059_spas")]
    partial class spas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusinessLayer.DriversLicense", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EGN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DriversLicenses");
                });

            modelBuilder.Entity("BusinessLayer.KAT", b =>
                {
                    b.Property<int>("KatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KatID"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KatID");

                    b.ToTable("KATs");
                });

            modelBuilder.Entity("BusinessLayer.LicensePlate", b =>
                {
                    b.Property<string>("PlateNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DateOfRegistration")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PlateType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("RegistratedInKatKatID")
                        .HasColumnType("int");

                    b.Property<string>("RegistratorPlateNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlateNumber");

                    b.HasIndex("RegistratedInKatKatID");

                    b.HasIndex("RegistratorPlateNumber");

                    b.ToTable("LicensePlates");
                });

            modelBuilder.Entity("BusinessLayer.LicensePlate", b =>
                {
                    b.HasOne("BusinessLayer.KAT", "RegistratedInKat")
                        .WithMany()
                        .HasForeignKey("RegistratedInKatKatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessLayer.LicensePlate", "Registrator")
                        .WithMany()
                        .HasForeignKey("RegistratorPlateNumber");

                    b.Navigation("RegistratedInKat");

                    b.Navigation("Registrator");
                });
#pragma warning restore 612, 618
        }
    }
}
