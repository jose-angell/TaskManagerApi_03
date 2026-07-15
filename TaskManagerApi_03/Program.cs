using Microsoft.EntityFrameworkCore;
using TaskManagerApi_03.Application;
using TaskManagerApi_03.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<EmployeeUseCase>();
builder.Services.AddScoped<TaskUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
