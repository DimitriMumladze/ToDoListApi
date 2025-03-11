using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoListApi.Domain.Repositories;
using ToDoListApi.Infrastructure.Persistence;
using ToDoListApi.Infrastructure.Repositories;

namespace ToDoListApi.Infrastructure.Extensions;

public static class ServiceCollectionsExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ToDoListDb");
        services.AddDbContext<ToDoListDbContext>(options => options.UseSqlServer(connectionString));
        //aq xom ar aklia ramis damateba netav?
        //kargad unda gaviazrot sheqmnis command
        services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();

    }
}
