﻿// <auto-generated />
using System;
using Loda.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Loda.Entity.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Loda.Entity.DataTable.DT_User", b =>
                {
                    b.Property<long>("user_id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("create_time");

                    b.Property<DateTime>("row_version")
                        .IsConcurrencyToken();

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("user_password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("user_id");

                    b.ToTable("DT_User");
                });
#pragma warning restore 612, 618
        }
    }
}