﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShinyRockForum.Data;

#nullable disable

namespace ShinyRockForum.Migrations
{
    [DbContext(typeof(ShinyRockForumContext))]
    [Migration("20250303191754_IdentityCreate2")]
    partial class IdentityCreate2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShinyRockForum.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscussionId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("DiscussionId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ShinyRockForum.Models.Discussion", b =>
                {
                    b.Property<int>("DiscussionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscussionId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageFilename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiscussionId");

                    b.ToTable("Discussion");
                });

            modelBuilder.Entity("ShinyRockForum.Models.Comment", b =>
                {
                    b.HasOne("ShinyRockForum.Models.Discussion", "Discussion")
                        .WithMany("Comments")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discussion");
                });

            modelBuilder.Entity("ShinyRockForum.Models.Discussion", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
