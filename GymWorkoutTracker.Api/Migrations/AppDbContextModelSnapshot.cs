﻿// <auto-generated />
using System;
using GymWorkoutTracker.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymWorkoutTracker.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymWorkoutTracker.Api.Models.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Excercises");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1b4835d4-1297-4195-aaea-d707c5150003"),
                            CreatedAt = new DateTime(2020, 2, 16, 21, 7, 10, 739, DateTimeKind.Local).AddTicks(3062),
                            Name = "Pull Ups"
                        },
                        new
                        {
                            Id = new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"),
                            CreatedAt = new DateTime(2020, 2, 16, 21, 7, 10, 743, DateTimeKind.Local).AddTicks(7274),
                            Name = "Lat Pull Down"
                        },
                        new
                        {
                            Id = new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"),
                            CreatedAt = new DateTime(2020, 2, 16, 21, 7, 10, 743, DateTimeKind.Local).AddTicks(7447),
                            Name = "Face Pulls"
                        });
                });

            modelBuilder.Entity("GymWorkoutTracker.Api.Models.WorkoutSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExcerciseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ExcerciseId");

                    b.ToTable("WorkoutSets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1cb9ef9f-c82f-45de-add7-1babf17bdbae"),
                            ExcerciseId = new Guid("1b4835d4-1297-4195-aaea-d707c5150003"),
                            Reps = 6,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(249),
                            Weight = -50f
                        },
                        new
                        {
                            Id = new Guid("15152250-9cd5-4848-bab0-597f03673b03"),
                            ExcerciseId = new Guid("1b4835d4-1297-4195-aaea-d707c5150003"),
                            Reps = 4,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1102),
                            Weight = -50f
                        },
                        new
                        {
                            Id = new Guid("ae4c8f20-90c8-4cc2-957b-eb55aceb54c6"),
                            ExcerciseId = new Guid("1b4835d4-1297-4195-aaea-d707c5150003"),
                            Reps = 3,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1175),
                            Weight = -50f
                        },
                        new
                        {
                            Id = new Guid("555eee9d-3a2f-478a-b07a-15abd791cee8"),
                            ExcerciseId = new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"),
                            Reps = 12,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1204),
                            Weight = 50f
                        },
                        new
                        {
                            Id = new Guid("e7567c90-9a83-4e28-878f-152cc9d09206"),
                            ExcerciseId = new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"),
                            Reps = 12,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1229),
                            Weight = 50f
                        },
                        new
                        {
                            Id = new Guid("409921cc-9e1d-4302-bca4-aa31d9df53e8"),
                            ExcerciseId = new Guid("6a78ad32-8621-40b3-b9b8-f2d518931ab5"),
                            Reps = 12,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1257),
                            Weight = 50f
                        },
                        new
                        {
                            Id = new Guid("8fc8f646-cab5-4798-8090-7f33595de415"),
                            ExcerciseId = new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"),
                            Reps = 6,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1283),
                            Weight = 20f
                        },
                        new
                        {
                            Id = new Guid("09677d11-edee-4d4b-91d4-ccbddd1b3c49"),
                            ExcerciseId = new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"),
                            Reps = 6,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1307),
                            Weight = 20f
                        },
                        new
                        {
                            Id = new Guid("297fbabe-01db-42ef-badc-57855d5bad12"),
                            ExcerciseId = new Guid("14ec1dd7-039c-4610-83cd-a14e92564059"),
                            Reps = 6,
                            TimeStamp = new DateTime(2020, 2, 16, 21, 7, 10, 744, DateTimeKind.Local).AddTicks(1332),
                            Weight = 20f
                        });
                });

            modelBuilder.Entity("GymWorkoutTracker.Api.Models.WorkoutSet", b =>
                {
                    b.HasOne("GymWorkoutTracker.Api.Models.Exercise", "Excercise")
                        .WithMany()
                        .HasForeignKey("ExcerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
