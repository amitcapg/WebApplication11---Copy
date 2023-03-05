using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.Extensions;
using WebApplication11.model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContactsAPIDbContext>(option =>
option.UseInMemoryDatabase(databaseName: "ContactAPIDb"));
builder.Services.AddScoped<DbInitializer>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseItToSeedSqlServer();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



