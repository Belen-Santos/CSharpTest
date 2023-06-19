﻿// <auto-generated />
using System;
using BelenSA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BelenSA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230617082646_CreatingDatabase")]
    partial class CreatingDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BelenSA.Models.ReasonSignUp", b =>
                {
                    b.Property<int>("ReasonSignUpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReasonSignUpId"), 1L, 1);

                    b.Property<string>("ReasonSigningUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("ReasonSignUpId");

                    b.ToTable("ReasonSignUp", (string)null);
                });

            modelBuilder.Entity("BelenSA.Models.Subscriber", b =>
                {
                    b.Property<int>("SubscriberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriberId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowTheyHeardAboutUs")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubscriptionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SubscriberId");

                    b.ToTable("Subscriber", (string)null);
                });

            modelBuilder.Entity("SubscribersReasonsSignUp", b =>
                {
                    b.Property<int>("ReasonsForSigningUpReasonSignUpId")
                        .HasColumnType("int")
                        .HasColumnName("ReasonSignUpId");

                    b.Property<int>("SubscribersSubscriberId")
                        .HasColumnType("int")
                        .HasColumnName("SubscriberId");

                    b.HasKey("ReasonsForSigningUpReasonSignUpId", "SubscribersSubscriberId");

                    b.HasIndex("SubscribersSubscriberId");

                    b.ToTable("SubscribersReasonsSignUp");
                });

            modelBuilder.Entity("SubscribersReasonsSignUp", b =>
                {
                    b.HasOne("BelenSA.Models.ReasonSignUp", null)
                        .WithMany()
                        .HasForeignKey("ReasonsForSigningUpReasonSignUpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BelenSA.Models.Subscriber", null)
                        .WithMany()
                        .HasForeignKey("SubscribersSubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
