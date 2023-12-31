using EntityFrameworkInMemory.Repositorios;
using EstudosApi.Domain.Interfaces;
using EstudosApi.Repository.DataBaseContext;
using EstudosApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepositorio, ProductRepositorio>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepositorio, CategoryRepositorio>();

builder.Services.AddDbContext<DBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
