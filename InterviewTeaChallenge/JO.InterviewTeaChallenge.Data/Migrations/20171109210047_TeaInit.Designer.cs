﻿// <auto-generated />
using JO.InterviewTeaChallenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JO.InterviewTeaChallenge.Data.Migrations
{
    [DbContext(typeof(TeaContext))]
    [Migration("20171109210047_TeaInit")]
    partial class TeaInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("JO.InterviewTeaChallenge.Data.Models.Tea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("RequiresMilk");

                    b.HasKey("Id");

                    b.ToTable("Tea");
                });
#pragma warning restore 612, 618
        }
    }
}
