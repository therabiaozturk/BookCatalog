using BookCatalog.Business.Services;
using Microsoft.EntityFrameworkCore;
using BookCatalog.Model.Interfaces;
using BookCatalog.DataAccess.Repositories;
using BookCatalog.DataAccess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// DbContext ba�lant�s�
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//her HTTP iste�i i�in yeni bir BookService nesnesi olu�turur.
//ve uygulama i�inde IBookService arayan yerlere BookService�i verir.
//B�ylece controller gibi yerlerde do�rudan kullanabilirsin.
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
