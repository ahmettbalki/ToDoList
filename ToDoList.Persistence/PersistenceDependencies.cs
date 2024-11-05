using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Services.Repositories;
using ToDoList.Persistence.Contexts;
using ToDoList.Persistence.Repositories;
namespace ToDoList.Persistence;
public static class PersistenceDependencies
{
    public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IToDoRepository, ToDoRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        return services;
    }
}
