
using BookLibraryApi.Repositories.Interface;
using BookLibraryApi.Repositories;
using BookLibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using BookLibraryApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Identity.Client;

namespace BookLibraryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<GenreRepository>();
            builder.Services.AddScoped<FilterRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            app.UseAuthorization();



            BookMethods.BookCrud(app);

            app.Run();
            
        }

    }
}