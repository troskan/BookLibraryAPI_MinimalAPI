﻿// <auto-generated />
using BookLibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLibraryApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookLibraryApi.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailableForLoan")
                        .HasColumnType("bit");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Jane Austen",
                            Description = "A classic novel of manners, love and society.",
                            Genre = "Classic",
                            IsAvailableForLoan = true,
                            PublicationYear = 1813,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "George Orwell",
                            Description = "A dystopian novel set in a totalitarian future.",
                            Genre = "Dystopia",
                            IsAvailableForLoan = true,
                            PublicationYear = 1949,
                            Title = "1984"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "Harper Lee",
                            Description = "A novel about racism and innocence in the American deep south.",
                            Genre = "Classic",
                            IsAvailableForLoan = true,
                            PublicationYear = 1960,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            BookId = 4,
                            Author = "J.R.R. Tolkien",
                            Description = "A fantasy novel about Bilbo Baggins and his adventurous journey.",
                            Genre = "Fantasy",
                            IsAvailableForLoan = true,
                            PublicationYear = 1937,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Frank Herbert",
                            Description = "A science fiction epic set in a desert world.",
                            Genre = "Science Fiction",
                            IsAvailableForLoan = true,
                            PublicationYear = 1965,
                            Title = "Dune"
                        },
                        new
                        {
                            BookId = 6,
                            Author = "J.D. Salinger",
                            Description = "A story about the struggles of adolescence.",
                            Genre = "Classic",
                            IsAvailableForLoan = true,
                            PublicationYear = 1951,
                            Title = "The Catcher in the Rye"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
