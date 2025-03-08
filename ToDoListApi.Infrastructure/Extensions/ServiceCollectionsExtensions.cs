using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoListApi.Infrastructure.Persistence;

namespace ToDoListApi.Infrastructure.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ToDoList");
        services.AddDbContext<ToDoListDbContext>(options => options.UseSqlServer(connectionString));
    }
}
