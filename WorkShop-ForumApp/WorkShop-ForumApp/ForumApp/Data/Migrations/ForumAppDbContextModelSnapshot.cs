﻿// <auto-generated />
using System;
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForumApp.Migrations
{
    [DbContext(typeof(ForumAppDbContext))]
    partial class ForumAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ForumApp.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd3ef825-1e94-40c1-b1d5-7a1f8ae576a8"),
                            Content = "My first post will be about performing CRUD operations in MVC. It's so much fun!",
                            Title = "My first Post"
                        },
                        new
                        {
                            Id = new Guid("c0b5977f-efe8-4911-9554-18d5bb9bc7b2"),
                            Content = "This is my second post. CRUD operations in MVC are getting more and more interesting!",
                            Title = "My second post"
                        },
                        new
                        {
                            Id = new Guid("50c8ee7c-c21f-4478-ac21-351b2c48aaff"),
                            Content = "Hello there! I'm getting better and better with the CRUD operations in MVC. Stay tunned!",
                            Title = "My third post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
