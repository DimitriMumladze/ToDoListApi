using ToDoListApi.Application.Extensions;
using ToDoListApi.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add your services BEFORE building the application
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Build the application AFTER adding all services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

