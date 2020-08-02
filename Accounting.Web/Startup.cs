using System;
using Accounting.BLL.Configurations;
using Accounting.BLL.Enums;
using Accounting.Settings.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Accounting.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            ConfigureDatabase(services);
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            var dbType = Configuration.GetSection("DatabaseType").Value;
            if (dbType.Equals(DataBaseType.MsSql.ToString()))
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                services.SetUpApplicationDependencies(connectionString, DataBaseType.MsSql);
                return;
            }
            if (dbType.Equals(DataBaseType.MongoDb.ToString()))
            {
                services.Configure<AccountingMongoDatabaseSettings>(Configuration.GetSection(nameof(AccountingMongoDatabaseSettings)));
                services.SetUpApplicationDependencies(null,DataBaseType.MongoDb);
                return;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMvc();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
