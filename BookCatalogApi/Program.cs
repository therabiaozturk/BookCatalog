using BookCatalog.Business.Services;
using Microsoft.EntityFrameworkCore;
using BookCatalog.Model.Interfaces;
using BookCatalog.DataAccess.Repositories;
using BookCatalog.DataAccess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// DbContext baðlantýsý
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//her HTTP isteði için yeni bir BookService nesnesi oluþturur.
//ve uygulama içinde IBookService arayan yerlere BookService’i verir.
//Böylece controller gibi yerlerde doðrudan kullanabilirsin.
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();


// Swagger vs.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
