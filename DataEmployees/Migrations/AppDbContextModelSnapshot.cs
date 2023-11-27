﻿// <auto-generated />
using System;
using DataEmployees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataEmployees.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("DataEmployees.Entities.EmployeesEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("employee_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Fire")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Hire")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrganizationID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("Stanowisko")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("DataEmployees.Entities.OrganizationEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("organizations");

                    b.HasData(
                        new
                        {
                            ID = 101,
                            Description = "Uczelnia",
                            Name = "WSEI"
                        },
                        new
                        {
                            ID = 102,
                            Description = "Koło studenckie",
                            Name = "Koło studenckie WSEI"
                        });
                });

            modelBuilder.Entity("DataEmployees.Entities.EmployeesEntity", b =>
                {
                    b.HasOne("DataEmployees.Entities.OrganizationEntity", "Organization")
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationID");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DataEmployees.Entities.OrganizationEntity", b =>
                {
                    b.OwnsOne("DataEmployees.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrganizationEntityID")
                                .HasColumnType("INTEGER");

                            b1.HasKey("OrganizationEntityID");

                            b1.ToTable("organizations");

                            b1.WithOwner()
                                .HasForeignKey("OrganizationEntityID");

                            b1.HasData(
                                new
                                {
                                    OrganizationEntityID = 101
                                },
                                new
                                {
                                    OrganizationEntityID = 102
                                });
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("DataEmployees.Entities.OrganizationEntity", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
