using FluentValidation;
using Mentor.Application.Commands;
using MongoDB.Driver;
using MediatR;
using Mentor.API.Filters;
using Mentor.API.Services;
using Mentor.Application.Common.Dto;
using Mentor.Application.Common.Validators;
using Mentor.Application.Services;
using Mentor.Application.Subject.Commands;
using Mentor.Application.Subject.Handlers;
using Mentor.Worker;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Load MongoDB configuration from appsettings.json
var mongoDbConfig = builder.Configuration.GetSection("MongoDbConfiguration");
string dbString = mongoDbConfig["DbString"]; 
string dbName = mongoDbConfig["DbName"];     

if (string.IsNullOrEmpty(dbString) || string.IsNullOrEmpty(dbName))
{
    throw new ArgumentNullException("Connection string or database name is not set in configuration.");
}

// Register MongoDB client and database
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(dbString));
builder.Services.AddSingleton<IMongoDatabase>(s => s.GetRequiredService<IMongoClient>().GetDatabase(dbName));

// Register MongoDbService with the required parameters
builder.Services.AddSingleton<MongoDbService>(s =>
{
    return new MongoDbService(dbString, dbName);
});

// Register services
builder.Services.AddHostedService<NotifyMentorsWorker>();
builder.Services.AddMediatR(typeof(AddMentorCommandHandler).Assembly);

// Register validators
builder.Services.AddTransient<IValidator<AddMentorCommand>, AddMentorCommandValidator>();
builder.Services.AddTransient<IRequestHandler<AddMentorCommand, IActionResult>, AddMentorCommandHandler>();
builder.Services.AddTransient<IValidator<AddSubjectCommand>, AddSubjectCommandValidator>();

// Configure MVC
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
