using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using skracacz.Interfaces;
using skracacz.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;

namespace skracacz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ILinksRepository, LinksRepository>();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Skracacz API", Version = "v1" }));
            services.AddDbContext<SkracaczDBContext>(options => options.UseSqlite(Configuration.GetConnectionString("SkracaczDbConnection")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseStaticFiles();


            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skracacz API"));
            app.UseSwagger();


            app.UseMvc(routes =>
            {
 
            routes.MapRoute(
                "RedirectRoute",                                           // Route name
                "{shortUrl}",              // URL with parameters
                new { controller = "Redirect", action = "RedirectToSite" }  // Parameter defaults
            );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=LinkApi}/{action=Index}/{id?}");
            });


        }
    }
}