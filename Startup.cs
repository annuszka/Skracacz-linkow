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
            services.AddSingleton<ILinksRepository, LinksRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
 
            routes.MapRoute(
                "RedirectRoute",                                           // Route name
                "{shortUrl}",              // URL with parameters
                new { controller = "Redirect", action = "RedirectToSite" }  // Parameter defaults
            );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Link}/{action=Index}");
            });
        }
    }
}