using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pumox_Test.Models;
using Pumox_Test.Services;
using Pumox_Test.Services.Authentication;

namespace Pumox_Test
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
            services.AddDbContext<SqlDbContext>(opt =>
            {
                opt.UseSqlServer("Data Source=db-mssql;Initial Catalog=s19434;Integrated Security=True");

            });
            services.AddTransient<IUserDbService, SqlServerUserDbService>();

            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, AuthenticationHandler>("BasicAuthentication", null);

            services.AddTransient<ICompanyDbService, SqlServerCompanyDbService>();
            services.AddTransient<IEmployeeDbService, SqlServerEmployeeDbService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
