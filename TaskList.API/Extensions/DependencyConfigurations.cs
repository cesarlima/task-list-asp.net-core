using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskList.API.Queries;
using TaskList.Domain.Handlers;
using TaskList.Domain.Repositories;
using TaskList.Infra.Contexts;
using TaskList.Infra.Repositories;
using TaskList.Infra.Transaction;

namespace TaskList.API.Extensions
{
    public static class DependencyConfigurations
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<TaskHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TaskQueries>();
        }
    }
}
