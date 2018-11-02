using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LondonAPI.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LondonAPI
{
    public class Startup
    {

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddMvc();
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

            app.UseCors("CorsPolicy");

            // app.UseForwardedHeaders will forward proxy headers to the current request. This will help us during the Linux deployment.
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
            //});

            //app.Use(async (context, next) => … will point on the index page in the Angular project.
            //app.Use(async (context, next) =>
            //{
            //    await next();

            //    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
            //    {
            //        context.Request.Path = "/index.html";
            //        await next();
            //    }
            //});

            // enables using static files for the request. If we don’t set a path to the static files, it will use a wwwroot folder in our solution explorer by default.
            //app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
