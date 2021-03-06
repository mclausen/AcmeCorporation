﻿// <auto-generated />
using System;
using AcmeCorporation.Draw.Infrastructure.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcmeCorporation.Draw.Infrastructure.Migrations
{
    [DbContext(typeof(DrawDbContext))]
    [Migration("20180816114831_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcmeCorporation.Draw.Domain.DrawSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("SerialNumberSerial");

                    b.Property<DateTime>("SubmissionTimeUtc");

                    b.HasKey("Id");

                    b.HasIndex("SerialNumberSerial");

                    b.ToTable("DrawSubmissions");
                });

            modelBuilder.Entity("AcmeCorporation.Draw.Domain.SerialNumber", b =>
                {
                    b.Property<string>("Serial")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreatedUtc");

                    b.Property<int>("UsageCount")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.HasKey("Serial");

                    b.ToTable("SerialNumbers");
                });

            modelBuilder.Entity("AcmeCorporation.Draw.Domain.DrawSubmission", b =>
                {
                    b.HasOne("AcmeCorporation.Draw.Domain.SerialNumber", "SerialNumber")
                        .WithMany()
                        .HasForeignKey("SerialNumberSerial");
                });
#pragma warning restore 612, 618
        }
    }
}
