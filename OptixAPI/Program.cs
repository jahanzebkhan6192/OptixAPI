using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OptixAPI.Data;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders(); 
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddDbContext<OptixContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IMovieRepository, MovieRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
