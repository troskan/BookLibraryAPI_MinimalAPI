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
            app.MapGet("books/{id}", ([FromServices] IRepository<Book> repo, int id) =>
            {
                ApiResponse response = new ApiResponse() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };

                var book = repo.GetById(id);

                if (book == null)
                {
                    return Results.NotFound(book);
                }
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = book;
                return Results.Ok(response);
            })
            .WithName("GetBookById")
            .WithOpenApi();


            //GetAllBooks
            app.MapGet("books", (IRepository<Book> repo) =>
            {
                var books = repo.GetAll();

                return books;

            })
            .WithName("GetBooks")
            .WithOpenApi(); 
            
                //GetAllGenres
                app.MapGet("genres", (GenreRepository repo) =>
                {
                    var genres = repo.GetGenres();

                    return genres;

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
                if (id <= 0)
                {
                    return Results.BadRequest("Invalid book ID provided.");
                }

                try
                {
                    var bookToDelete = repo.GetById(id);

                    if (bookToDelete == null)
                    {
                        return Results.NotFound($"Book with ID {id} not found.");
                    }

                    repo.Delete(bookToDelete);
                    return Results.Ok(bookToDelete);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"An error occurred trying to delete data.\n{ex.Message}");
                }

            })
            .WithName("DeleteBook")
            .WithOpenApi();

            //UpdateBook
            app.MapPut("book/{id}", (int id, Book updatedBook, IRepository<Book> repo) =>
            {

                try
                {

                    var bookToUpdate = repo.GetById(id);

                    if (updatedBook == null)
                    {
                        return Results.NotFound($"Book object is null.");
                    }
                    bookToUpdate.Author = updatedBook.Author;
                    bookToUpdate.PublicationYear = updatedBook.PublicationYear;
                    bookToUpdate.Description = updatedBook.Description;
                    bookToUpdate.Genre = updatedBook.Genre;
                    bookToUpdate.Title = updatedBook.Title;

                    repo.Update(bookToUpdate);
                    return Results.Ok(bookToUpdate);
                }
                catch (Exception ex)
                {
                    return Results.Problem($"An error occurred trying to update data.\n{ex.Message}");
                }

            })
            .WithName("UpdateBook")
            .WithOpenApi();
            app.Run();
        }
    }
}
