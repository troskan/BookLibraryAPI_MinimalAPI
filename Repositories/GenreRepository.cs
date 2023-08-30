using BookLibraryApi.Data;

namespace BookLibraryApi.Repositories
{
    public class GenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<string> GetGenres()
        {
            try
            {
                var books = _context.Books.ToList();
                var genres = new List<string>();

                foreach (var book in books)
                {
                    string genre = book.Genre;
                    if (!genres.Contains(genre))
                    {
                        genres.Add(genre);
                    }
                }
                return genres;

            }
            catch (Exception ex)
            {
                var books = new List<string>();
                books.Add(ex.Message);
                return books;
                throw;
            }


        }
    }
}
