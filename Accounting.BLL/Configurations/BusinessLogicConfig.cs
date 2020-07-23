using Accounting.BLL.Abstract;
using Accounting.BLL.Services;
using Accounting.Domain.Abstract;
using Accounting.Domain.EFContext;
using Accounting.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Accounting.BLL.Configurations
{
    public static class BusinessLogicConfig
    {
        public static void ConfigureBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<PositionEmployeeRepository>();

        }
        public static IServiceCollection SetUpAppDatabaseDependencies(this IServiceCollection serviceCollection,
      string connectionString)
        {
            serviceCollection.AddDbContext<AccountingContext>(options => options.UseSqlServer(connectionString));
            return serviceCollection;
        }

    }
}
