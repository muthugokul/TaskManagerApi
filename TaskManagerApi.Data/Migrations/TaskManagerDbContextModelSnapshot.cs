﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagerApi.Data;

namespace TaskManagerApi.Data.Migrations
{
    [DbContext(typeof(TaskManagerDbContext))]
    [ExcludeFromCodeCoverage]
    partial class TaskManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagerApi.Model.ParentTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ParentTasks");
                });

            modelBuilder.Entity("TaskManagerApi.Model.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentTaskId");

                    b.Property<int>("Priority");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ParentTaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagerApi.Model.Task", b =>
                {
                    b.HasOne("TaskManagerApi.Model.ParentTask", "ParentTask")
                        .WithMany()
                        .HasForeignKey("ParentTaskId");
                });
#pragma warning restore 612, 618
        }
    }
}
