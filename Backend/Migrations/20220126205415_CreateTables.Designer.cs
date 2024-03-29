﻿// <auto-generated />
using System;
using Chatty.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220126205415_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Chatty.Models.Contact", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("NickName")
                        .HasColumnType("text");

                    b.Property<byte[]>("User")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("Id");

                    b.HasIndex("User");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Chatty.Models.Message", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("ContactId")
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("MessageContent")
                        .HasColumnType("text");

                    b.Property<long>("UnixTimestamp")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Chatty.Models.User", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Chatty.Models.Contact", b =>
                {
                    b.HasOne("Chatty.Models.User", "Owner")
                        .WithMany("Contacts")
                        .HasForeignKey("User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chatty.Models.Message", b =>
                {
                    b.HasOne("Chatty.Models.Contact", "Contact")
                        .WithMany("Messages")
                        .HasForeignKey("ContactId");
                });
#pragma warning restore 612, 618
        }
    }
}
