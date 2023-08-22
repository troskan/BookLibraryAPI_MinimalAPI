using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibraryApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    IsAvailableForLoan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Description", "Genre", "IsAvailableForLoan", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "Jane Austen", "A classic novel of manners, love and society.", "Classic", true, 1813, "Pride and Prejudice" },
                    { 2, "George Orwell", "A dystopian novel set in a totalitarian future.", "Dystopia", true, 1949, "1984" },
                    { 3, "Harper Lee", "A novel about racism and innocence in the American deep south.", "Classic", true, 1960, "To Kill a Mockingbird" },
                    { 4, "J.R.R. Tolkien", "A fantasy novel about Bilbo Baggins and his adventurous journey.", "Fantasy", true, 1937, "The Hobbit" },
                    { 5, "Frank Herbert", "A science fiction epic set in a desert world.", "Science Fiction", true, 1965, "Dune" },
                    { 6, "J.D. Salinger", "A story about the struggles of adolescence.", "Classic", true, 1951, "The Catcher in the Rye" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
