﻿// <auto-generated />
using System;
using Library.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Infrastructure.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20190212163812_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Core.Domain.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fullname");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Core.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<int>("Stock");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Core.Domain.Borrow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<DateTime>("BorrowDate");

                    b.Property<DateTime?>("ReturnDate");

                    b.Property<string>("Status");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("Library.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Library.Core.Domain.Book", b =>
                {
                    b.HasOne("Library.Core.Domain.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Core.Domain.Borrow", b =>
                {
                    b.HasOne("Library.Core.Domain.User", "User")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}