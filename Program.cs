using landscape_be.data;
using landscape_be.mapping;
using landscape_be.services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy => policy
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add EF Core DbContext using the current connection string
var connectionString = "Server=localhost\\SQLEXPRESS;Database=Landscape;TrustServerCertificate=true;Trusted_Connection=True;";
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<EmployeeService>();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<EmployeeProfile>());
// enable CORS
var app = builder.Build();
app.UseCors("AllowReact");


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
