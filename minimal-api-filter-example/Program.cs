using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalApiFilterExample;
using MinimalApiFilterExample.Endpoints;
using MinimalApiFilterExample.Models;
using MinimalApiFilterExample.Services;
using MinimalApiFilterExample.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExampleContext>(options => options.UseInMemoryDatabase("ExampleDatabase"));

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IValidator<Contact>, ContactValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapContactEndpoints();

app.Run();