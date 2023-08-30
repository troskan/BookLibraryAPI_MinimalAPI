using BookLibraryApi.Models;
using BookLibraryApi.Repositories;
using BookLibraryApi.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace BookLibraryApi
{
    public static class BookMethods
    {
        public static void BookCrud(WebApplication app)
        {
            //GetBookById
            app.MapGet("book/{id}", ([FromServices] IRepository<Book> repo, int id) =>
            {
                ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

                var book = repo.GetById(id);

                if (book == null)
                {
                    response.ErrorMessages.Add("Model is null");
                    response.StatusCode = HttpStatusCode.NotFound;

                    return response;
                }
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = book;

                return response;

            })
            .WithName("GetBookById")
            .WithOpenApi();


            //GetAllBooks
            app.MapGet("book", (HttpContext context, IRepository<Book> repo) =>
            {
                ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

                var books = repo.GetAll();

                if (books != null)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Result = books;

                    return response;
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    return response;
                }
            })
            .WithName("GetBooks")
            .WithOpenApi();


            //GetAllGenres
            app.MapGet("genres", async (GenreRepository repo) =>
                {
                    ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

                    response.Result = repo.GetGenres();
                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    return Results.Ok(response);
                })
                .WithName("GetGenres")
                .WithOpenApi();

            app.MapGet("search", (string searchString, FilterRepository repo) =>
            {
                var result = repo.Search(searchString);
                return result;
            })
            .WithName("GetResults")
            .WithOpenApi();

            //CreateBook
            app.MapPost("book", (Book newBook, IRepository<Book> repo) =>
            {
                if (newBook != null)
                {
                    try
                    {
                        repo.Add(newBook);

                        return Results.Created($"/books/{newBook.BookId}", newBook);
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem($"An error occurred trying to add new data.\n{ex.Message}");
                    }
                }
                else
                {
                    return Results.BadRequest("Invalid book data provided.");
                }
            })
            .WithName("AddBook")
            .WithOpenApi();

            //DeleteBook
            app.MapDelete("book/{id}", (int id, IRepository<Book> repo) =>
            {
                ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

                if (id <= 0)
                {
                    response.StatusCode= HttpStatusCode.BadRequest;
                    return response;
                }

                try
                {
                    var bookToDelete = repo.GetById(id);

                    if (bookToDelete == null)
                    {
                        response.StatusCode = HttpStatusCode.NotFound;
                        return response;
                    }

                    repo.Delete(bookToDelete);
                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Result = bookToDelete;
                    return response;
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages.Add(ex.Message);

                    return response;

                }

            })
            .WithName("DeleteBook")
            .WithOpenApi();

            //UpdateBook
            app.MapPut("book/{id}", (int id, Book updatedBook, IRepository<Book> repo) =>
            {
                ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

                try
                {
                    var bookToUpdate = repo.GetById(id);

                    if (updatedBook == null)
                    {
                        response.StatusCode = HttpStatusCode.NotFound;
                        return response;
                    }
                    bookToUpdate.Author = updatedBook.Author;
                    bookToUpdate.PublicationYear = updatedBook.PublicationYear;
                    bookToUpdate.Description = updatedBook.Description;
                    bookToUpdate.Genre = updatedBook.Genre;
                    bookToUpdate.Title = updatedBook.Title;

                    repo.Update(bookToUpdate);
                    response.StatusCode = HttpStatusCode.OK;
                    response.IsSuccess = true;
                    response.Result = bookToUpdate;
                    return response;
                }
                catch (Exception ex)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.ErrorMessages.Add($"{ex.Message}");
                    response.IsSuccess = false;
                    return response;
                }

            })
            .WithName("UpdateBook")
            .WithOpenApi();
            app.Run();
        }
    }
}
