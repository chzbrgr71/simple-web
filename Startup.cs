using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // Gather values for frontend service 
                string appVersion = "1.0.0";
                string frontendName = Environment.MachineName;

                await context.Response.WriteAsync("<h1>.NET Core Web App</h1>");
                await context.Response.WriteAsync("<p>App version: " + appVersion);
                await context.Response.WriteAsync("<br>");
                await context.Response.WriteAsync("<p>Container machine name: " + frontendName);

            });
        }
    }
}
