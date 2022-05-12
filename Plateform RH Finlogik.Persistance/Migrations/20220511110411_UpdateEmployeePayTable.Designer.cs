﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plateform_RH_Finlogik.Persistance;

#nullable disable

namespace Plateform_RH_Finlogik.Persistance.Migrations
{
    [DbContext(typeof(PlateformRHDbcontext))]
    [Migration("20220511110411_UpdateEmployeePayTable")]
    partial class UpdateEmployeePayTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.ApplicationOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AssignmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CoverLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CvUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCandidat")
                        .HasColumnType("int");

                    b.Property<int>("IdOffer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCandidat");

                    b.HasIndex("IdOffer");

                    b.ToTable("ApplicationOffer");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Candidat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidats");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Contrat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contrat");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departement");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CNSSNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Cin")
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diplome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("HoursPerWeek")
                        .HasColumnType("real");

                    b.Property<int>("IdDepartement")
                        .HasColumnType("int");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonnelEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonnelPhone")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkPhone")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int>("postalCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartement");

                    b.HasIndex("IdRole");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.EmployeePay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("FixedSalary")
                        .HasColumnType("bigint");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int?>("MealTicket")
                        .HasColumnType("int");

                    b.Property<string>("Prime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TciketPassGift")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEmployee");

                    b.ToTable("EmployeePay");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.EmployeePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdPost");

                    b.ToTable("EmployeePost");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.HistoryContrat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdContrat")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdContrat");

                    b.HasIndex("IdEmployee");

                    b.ToTable("HistoryContrat");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.LeaveBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("IdLeaveType")
                        .HasColumnType("int");

                    b.Property<float>("numberDays")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdLeaveType");

                    b.ToTable("LeaveBalance");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LeaveType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Sick leave"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Paid leave"
                        });
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameCandidat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("OfferDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfferMinExperience")
                        .HasColumnType("int");

                    b.Property<string>("OfferName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.TimeOffBalances", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndDateQuantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("IdLeaveType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartDateQuantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdLeaveType");

                    b.ToTable("TimeOffBalances");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.ApplicationOffer", b =>
                {
                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Candidat", "Candidat")
                        .WithMany("ApplicationOffers")
                        .HasForeignKey("IdCandidat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Offer", "Offer")
                        .WithMany("ApplicationOffers")
                        .HasForeignKey("IdOffer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidat");

                    b.Navigation("Offer");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Departement", "Departement")
                        .WithMany("Employees")
                        .HasForeignKey("IdDepartement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.EmployeePay", b =>
                {
                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeePay")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.EmployeePost", b =>
                {
                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeePosts")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Post", "Post")
                        .WithMany("EmployeePosts")
                        .HasForeignKey("IdPost")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.HistoryContrat", b =>
                {
                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Contrat", "Contrat")
                        .WithMany("HistoryContrats")
                        .HasForeignKey("IdContrat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Employee", "Employee")
                        .WithMany("HistoryContrats")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contrat");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.LeaveBalance", b =>
                {
                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Employee", "Employee")
                        .WithMany("LeaveBalance")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.LeaveType", "LeaveType")
                        .WithMany("LeaveBalance")
                        .HasForeignKey("IdLeaveType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.TimeOffBalances", b =>
                {
                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.Employee", "Employee")
                        .WithMany("TimeOffBalances")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plateform_RH_Finlogik.Domain.Entities.LeaveType", "LeaveType")
                        .WithMany()
                        .HasForeignKey("IdLeaveType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Candidat", b =>
                {
                    b.Navigation("ApplicationOffers");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Contrat", b =>
                {
                    b.Navigation("HistoryContrats");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Departement", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployeePay");

                    b.Navigation("EmployeePosts");

                    b.Navigation("HistoryContrats");

                    b.Navigation("LeaveBalance");

                    b.Navigation("TimeOffBalances");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.LeaveType", b =>
                {
                    b.Navigation("LeaveBalance");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Offer", b =>
                {
                    b.Navigation("ApplicationOffers");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Post", b =>
                {
                    b.Navigation("EmployeePosts");
                });

            modelBuilder.Entity("Plateform_RH_Finlogik.Domain.Entities.Role", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
