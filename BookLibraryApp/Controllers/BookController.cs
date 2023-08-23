using BookLibraryApi.Models;
using BookLibraryApi.Repositories.Interface;
using BookLibraryApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;

namespace BookLibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BookController> _logger;
        public BookController(HttpClient httpClient, ILogger<BookController> logger)
        {
            _logger = logger;
            _httpClient = httpClient;   

        }
        // GET: BookController
        public async Task<ActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7262/books");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var books = JsonConvert.DeserializeObject<List<Book>>(jsonResponse);
                return View(books);
            }
            return View("error");
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //GETGenres
        // POST: BookController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var apiUrl = "https://localhost:7262/genres";
            var response = await _httpClient.GetAsync(apiUrl);
            List<string> genres = new List<string>();

            if (response.IsSuccessStatusCode)
            {
                genres = await response.Content.ReadFromJsonAsync<List<string>>();
            }
            _logger.LogInformation("Inside Create");
            return View(genres);

        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var apiUrl = "https://localhost:7262/book";
                try
                {
                    var response = await _httpClient.PostAsJsonAsync(apiUrl, book);

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("Post Successful");
                        return RedirectToAction("Index");

                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    return View("Error");
                }

            }
            return View(book);

        }

        public async Task<ActionResult> Edit(int id)
        {
            var bookApi = $"https://localhost:7262/books/{id}";
            var genresUrl = "https://localhost:7262/genres";

            var bookResponse = await _httpClient.GetAsync(bookApi);
            _logger.LogInformation($"Response from API: {await bookResponse.Content.ReadAsStringAsync()}");

            if (!bookResponse.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to retrieve book object.");
                return View("Error");
            }
            var bookToEdit = await bookResponse.Content.ReadFromJsonAsync<Book>();

            var genreResponse = await _httpClient.GetAsync(genresUrl);
            if (!genreResponse.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to retrieve genre object.");
                return View("Error");
            }
            var genres = await genreResponse.Content.ReadFromJsonAsync<List<string>>();

            var viewModel = new BookEditViewModel
            {
                Book = bookToEdit,
                Genres = genres
            };

            return View(viewModel);
        }
        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
