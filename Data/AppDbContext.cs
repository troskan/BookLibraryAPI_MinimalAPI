using BookLibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Pride and Prejudice",
                    Author = "Jane Austen",
                    Description = "A classic novel of manners, love and society.",
                    Genre = "Classic",
                    PublicationYear = 1813,
                    IsAvailableForLoan = true
                },
                new Book
                {
                    BookId = 2,
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "A dystopian novel set in a totalitarian future.",
                    Genre = "Dystopia",
                    PublicationYear = 1949,
                    IsAvailableForLoan = true
                },
                new Book
                {
                    BookId = 3,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = "A novel about racism and innocence in the American deep south.",
                    Genre = "Classic",
                    PublicationYear = 1960,
                    IsAvailableForLoan = true
                },
                new Book
                {
                    BookId = 4,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    Description = "A fantasy novel about Bilbo Baggins and his adventurous journey.",
                    Genre = "Fantasy",
                    PublicationYear = 1937,
                    IsAvailableForLoan = true
                },
                new Book
                {
                    BookId = 5,
                    Title = "Dune",
                    Author = "Frank Herbert",
                    Description = "A science fiction epic set in a desert world.",
                    Genre = "Science Fiction",
                    PublicationYear = 1965,
                    IsAvailableForLoan = true
                },
                new Book
                {
                    BookId = 6,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Description = "A story about the struggles of adolescence.",
                    Genre = "Classic",
                    PublicationYear = 1951,
                    IsAvailableForLoan = true
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
