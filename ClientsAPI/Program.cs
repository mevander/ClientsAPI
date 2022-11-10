using Microsoft.EntityFrameworkCore;
using ClientsAPI.Data;
using Microsoft.Extensions.Configuration;
using ClientsAPI.Data.Entities;
using FluentValidation;
using ClientsAPI.Validators;
using ClientsAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClientsContextDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapClientEndpoints();

app.UseHttpsRedirection();

app.Run();