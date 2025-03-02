﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmsServer.Database;

#nullable disable

namespace SmsServer.Migrations
{
    [DbContext(typeof(SmsDBContext))]
    partial class SmsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmsServer.Database.Model.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("NNOEID")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SVNR")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("SamariterbundID")
                        .HasColumnType("bigint");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SmsServer.Database.Model.EmployeeEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EventId");

                    b.ToTable("EmployeeEvents");
                });

            modelBuilder.Entity("SmsServer.Database.Model.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ContactEmployeeId")
                        .HasColumnType("bigint");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContactEmployeeId");

                    b.HasIndex("CreatedById");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SmsServer.Database.Model.File", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UploadedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UploadedbyId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UploadedbyId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SmsServer.Database.Model.News", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AttachmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentId");

                    b.HasIndex("CreatedById");

                    b.ToTable("News");
                });

            modelBuilder.Entity("SmsServer.Database.Model.EmployeeEvent", b =>
                {
                    b.HasOne("SmsServer.Database.Model.Employee", "Employee")
                        .WithMany("AttendsEvents")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmsServer.Database.Model.Event", "Event")
                        .WithMany("AttendedBy")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("SmsServer.Database.Model.Event", b =>
                {
                    b.HasOne("SmsServer.Database.Model.Employee", "ContactEmployee")
                        .WithMany("ContactInEvents")
                        .HasForeignKey("ContactEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmsServer.Database.Model.Employee", "CreatedBy")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactEmployee");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("SmsServer.Database.Model.File", b =>
                {
                    b.HasOne("SmsServer.Database.Model.Employee", "Uploadedby")
                        .WithMany("UploadedFiles")
                        .HasForeignKey("UploadedbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uploadedby");
                });

            modelBuilder.Entity("SmsServer.Database.Model.News", b =>
                {
                    b.HasOne("SmsServer.Database.Model.File", "Attachment")
                        .WithMany("UsedInNews")
                        .HasForeignKey("AttachmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmsServer.Database.Model.Employee", "CreatedBy")
                        .WithMany("CreatedNews")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attachment");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("SmsServer.Database.Model.Employee", b =>
                {
                    b.Navigation("AttendsEvents");

                    b.Navigation("ContactInEvents");

                    b.Navigation("CreatedEvents");

                    b.Navigation("CreatedNews");

                    b.Navigation("UploadedFiles");
                });

            modelBuilder.Entity("SmsServer.Database.Model.Event", b =>
                {
                    b.Navigation("AttendedBy");
                });

            modelBuilder.Entity("SmsServer.Database.Model.File", b =>
                {
                    b.Navigation("UsedInNews");
                });
#pragma warning restore 612, 618
        }
    }
}
