﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schedule.Meetings.Infrastructure.Data.Context;

namespace Schedule.Meetings.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ScheduleMeetingsContext))]
    partial class ScheduleMeetingsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Schedule.Meetings.Domain.Entities.Rooms", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Description = "1° Andar",
                            Name = "Sala de reunião 1"
                        },
                        new
                        {
                            RoomId = 2,
                            Description = "2° andar",
                            Name = "Sala de reunião 2"
                        },
                        new
                        {
                            RoomId = 3,
                            Description = "3° andar",
                            Name = "Sala de reunião 3"
                        });
                });

            modelBuilder.Entity("Schedule.Meetings.Domain.Entities.ScheduleMeetings", b =>
                {
                    b.Property<int>("ScheduleMeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("MeetingEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("MeetingStart")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ScheduleMeetingId");

                    b.ToTable("ScheduleMeetings");
                });

            modelBuilder.Entity("Schedule.Meetings.Domain.Entities.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "e10adc3949ba59abbe56e057f20f883e",
                            Username = "LuizHenrique"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "e10adc3949ba59abbe56e057f20f883e",
                            Username = "Miranda"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
