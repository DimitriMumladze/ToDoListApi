using ToDoListApi.Application.Extensions;
using ToDoListApi.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register application and infrastructure services
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Register controllers
builder.Services.AddControllers();

// Build the application AFTER adding all services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable routing and controllers
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); 

app.Run();
