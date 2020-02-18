using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Training.Middleware;

namespace Training
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Headers["Authorization"] == "langit biru")
            //    {
            //        await next();
            //        return;
            //    }
            //    var text = "Not Authorize";

            //    var data = System.Text.Encoding.UTF8.GetBytes(text);
            //    await context.Response.Body.WriteAsync(data, 0, data.Length);
            //    //Console.WriteLine("Not Authorize");
            //});
            // sudah dipindah ke file authmiddleware.cs kemudian diganti

            //app.UseMiddleware<CustomAuthMiddleware>();
            //selain itu bisa juga pake  ini, extension method

            app.UseCustomAuthMiddleware();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
