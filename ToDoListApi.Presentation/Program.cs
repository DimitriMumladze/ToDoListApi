using ToDoListApi.Application.Extensions;
using ToDoListApi.Infrastructure.Extensions;
using ToDoListApi.Infrastructure.Seeder;

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

    // Seed the database in development environment
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            // Call the seeder
            await DatabaseSeeder.SeedDatabaseAsync(services);
            Console.WriteLine("Database seeded successfully.");
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}

app.UseHttpsRedirection();

// Enable routing and controllers
app.UseRouting();
app.UseAuthorization();
app.MapControllers(); 

app.Run();
