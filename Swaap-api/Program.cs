

using Microsoft.EntityFrameworkCore;
using SwaapApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<SwaapContext>(opt =>
//    opt.UseInMemoryDatabase("SwaapDB"));

builder.Services.AddDbContext<SwaapContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SwaapContext")));

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

