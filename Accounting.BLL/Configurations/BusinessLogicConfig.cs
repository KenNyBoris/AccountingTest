using Accounting.BLL.Abstract;
using Accounting.BLL.Enums;
using Accounting.BLL.Services;
using Accounting.BLL.Services.NoSql;
using Accounting.BLL.Services.Sql;
using Accounting.Domain.Abstract.NoSql.Interfaces;
using Accounting.Domain.Abstract.Sql.Interfaces;
using Accounting.Domain.EFContext;
using Accounting.Domain.Repositories;
using Accounting.NoSqlDomain.Repositories;
using Accounting.Settings.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Accounting.BLL.Configurations
{
    public static class BusinessLogicConfig
    {

        public static IServiceCollection SetUpApplicationDependencies(this IServiceCollection serviceCollection,
            string connectionString, DataBaseType dbType)
        {
            switch (dbType)
            {
                case DataBaseType.MsSql:
                    ConfigureMsSqlDependencies(serviceCollection, connectionString);
                    break;
                case DataBaseType.MongoDb:
                    ConfigureMongoDependencies(serviceCollection);
                    break;
            }
            return serviceCollection;
        }

        private static void ConfigureMsSqlDependencies(IServiceCollection serviceCollection,string connectionString)
        {
            serviceCollection.AddDbContext<AccountingContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            serviceCollection.AddScoped<IPositionRepository, PositionRepository>();
            serviceCollection.AddScoped<IPositionEmployeeRepository, PositionEmployeeRepository>();
            serviceCollection.AddScoped<IEmployeeService, EmployeeService>();
            serviceCollection.AddScoped<IPositionService, PositionService>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        private static void ConfigureMongoDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAccountingDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<AccountingMongoDatabaseSettings>>().Value);
            serviceCollection.AddScoped<IEmployeeNoSqlRepository, EmployeeMongoRepository>();
            serviceCollection.AddScoped<IPositionNoSqlRepository, PositionMongoRepository>();
            serviceCollection.AddScoped<IEmployeeService, EmployeeNoSqlService>();
            serviceCollection.AddScoped<IPositionService, PositionNoSqlService>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MongoMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
