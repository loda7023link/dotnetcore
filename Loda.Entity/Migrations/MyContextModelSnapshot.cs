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
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnName("create_time");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .HasColumnName("row_version");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("user_name")
                        .HasMaxLength(50);

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnName("user_password")
                        .HasMaxLength(32);

                    b.HasKey("UserId");

                    b.ToTable("DT_User");
                });
#pragma warning restore 612, 618
        }
    }
}
