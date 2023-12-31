﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcessMappingApi.Data;

#nullable disable

namespace ProcessMappingApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20231218195347_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProcessMappingApi.Models.Domain.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("ProcessMappingApi.Models.Domain.CompanyProcess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentCompanyProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SubCompanyProcessOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CompanyProcessId");

                    b.ToTable("CompanyProcesses");
                });

            modelBuilder.Entity("ProcessMappingApi.Models.Domain.CompanyProcess", b =>
                {
                    b.HasOne("ProcessMappingApi.Models.Domain.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcessMappingApi.Models.Domain.CompanyProcess", null)
                        .WithMany("CompanyProcesses")
                        .HasForeignKey("CompanyProcessId");

                    b.Navigation("Area");
                });

            modelBuilder.Entity("ProcessMappingApi.Models.Domain.CompanyProcess", b =>
                {
                    b.Navigation("CompanyProcesses");
                });
#pragma warning restore 612, 618
        }
    }
}
