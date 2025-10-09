using BookManagementSystemAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BookManagementSystemAPI.Exceptions;
using BookManagementSystemAPI.Repository;
using BookManagementSystemAPI.Services;

namespace BookManagementSystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookDb"))
            );


            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();

            
            builder.Services.AddSingleton<GlobalExceptionHandler>();

            var app = builder.Build();
            
            app.UseExceptionHandler(errorApp => errorApp.Run(async context =>
                {
                    var exceptionHandler = context.RequestServices.GetRequiredService<GlobalExceptionHandler>();
                    await exceptionHandler.HandleExceptionAsync(context);
                }
            ));
            
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}