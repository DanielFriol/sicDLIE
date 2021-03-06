﻿// <auto-generated />
using Hahn.ApplicatonProcess.May2020.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hahn.ApplicatonProcess.May2020.Data.EF.Migrations
{
    [DbContext(typeof(ApplicationProjectDataContext))]
    [Migration("20200527000156_teste")]
    partial class teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Hahn.ApplicatonProcess.May2020.Domain.Entities.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CountryOfOrigin")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EmailAdress")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FamilyName")
                        .HasColumnType("varchar(80)");

                    b.Property<sbyte>("Hired")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });
#pragma warning restore 612, 618
        }
    }
}
