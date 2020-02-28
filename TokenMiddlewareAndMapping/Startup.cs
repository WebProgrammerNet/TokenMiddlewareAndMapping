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
using TokenMiddlewareAndMapping.MiddlewareSource;

namespace TokenMiddlewareAndMapping
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuratioon = configuration;
        }
        private IConfiguration Configuratioon;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

        }
        //ConfigureServices metod Ragestriruet vse servisi kotoriy mi budem ispolzovat na nashemprilojeniye.
        //bez etovo metoda program bojet rabotat.
        //ConfigureServices upravlenie dobavlenie services

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            app.UseMiddleware<TokenMiddleware_v1>();
            app.UseToken();



            // app.Run(Handle);

            //Map aciq olsa isleyecek
            //app.Map("/index", (delegete) =>
            //{
            //    delegete.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("<h1>Home Page</h1>");
            //    });
            //});
            //app.Map("", (delegete) =>
            //{
            //    delegete.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("<h1>No Any Page</h1>");

            //    });
            //});

            app.Run(Handle);
            #region
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}"
            //        );
            //});


            //Configure method dlya obrobativanie zaprosov.
            //Dlya obrobotka zaprosa danniy method prinimaet paranetr IApplicationBuilder 
            //S pomoshiu etovo parametra  mi smojem stroit konveyere obrabotki zaprosa razlicnie komponenti.
            //Parametr IApplicationBuilder yavlyaetsya obezatelnim. Druqie parametri ne pbezatelni.

            // app.Run(async (context) =>
            //{
            //    string host = context.Request.Host.Value;
            //    string path = context.Request.Path;
            //    string query = context.Request.QueryString.Value;
            //    context.Response.ContentType = "text/html;charset=utf-8";
            //    await context.Response.WriteAsync(
            //        $"<h3>Host: {host}</h3> +\n" +
            //        $"<h3>Path: {path}</h3> +\n" +
            //        $"<h3>Query String: {query}</h3>");
            //});

            #endregion

            async Task Handle(HttpContext context)
            {
                string host = context.Request.Host.Value;
                string path = context.Request.Path;
                string query = context.Request.QueryString.Value;
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(
                    $"<h3>Host: {host}</h3> +\n" +
                    $"<h3>Path: {path}</h3> +\n" +
                    $"<h3>Query String: {query}</h3>");
            }
        }
    }
}
