using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using Swintake.domain.Data;
using Swintake.infrastructure.Exceptions;
using Swintake.infrastructure.Logging;

namespace Swintake.api
{
    public class Startup
    {

        private string _connectionstring = ".\\SQLExpress";
        public Startup(IConfiguration configuration, ILoggerFactory logFactory)
        {
            var foo = Environment.GetEnvironmentVariable("ParkSharkSql", EnvironmentVariableTarget.User);
            if (foo != null && foo.Equals("SqlServer"))
            {
                _connectionstring = "(LocalDb)\\MSSQLLocalDb";
            }
            Configuration = configuration;
            ApplicationLogging.LoggerFactory = logFactory;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton(ConfigureDbContext());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
        }

        protected virtual DbContextOptions<SwintakeContext> ConfigureDbContext()
        {
            return new DbContextOptionsBuilder<SwintakeContext>()
                .UseSqlServer($"Data Source={_connectionstring};Initial Catalog=Swintake;Integrated Security=True;")
                .Options;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling =
                    PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Swintake API";
                    document.Info.Description = "An API for Swintake";
                };
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
//test