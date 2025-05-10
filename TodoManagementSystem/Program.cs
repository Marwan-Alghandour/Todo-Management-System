using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using RepositoryContracts;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITodosRepository, TodosRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddDbContext<TodoDbContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TodoManagementSystem")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
