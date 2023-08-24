using BookLibraryApi.Data;
using BookLibraryApi.Models;

namespace BookLibraryApi.Repositories
{
    public class FilterRepository
    {
        private readonly AppDbContext _context;

        public FilterRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> Search(string searchString)
        {
            try
            {
                var books = _context.Books.ToList();
                var searchResult = new List<Book>();

                foreach (var book in books)
                {
                    if (book.Title.ToString().ToLower().Contains(searchString.ToLower()) ||
                       (book.Author.ToString().ToLower().Contains(searchString.ToLower())) ||
                       (book.Description.ToString().ToLower().Contains(searchString.ToLower())) ||
                       (book.Genre.ToString().ToLower().Contains(searchString.ToLower())) ||
                       (book.BookId.ToString().ToLower().Contains(searchString.ToLower())))
                    { 
                    searchResult.Add(book);
                    }
                }
                return searchResult;

            }
            catch (Exception ex)
            {
                return null;
                throw;
            }


        }
    }
}
