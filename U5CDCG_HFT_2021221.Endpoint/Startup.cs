using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U5CDCG_HFT_2021221.Data;
using U5CDCG_HFT_2021221.Endpoint.Services;
using U5CDCG_HFT_2021221.Logic;
using U5CDCG_HFT_2021221.Repository;

namespace U5CDCG_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IBookLogic, BookLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<ILibraryLogic, LibraryLogic>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<LibraryDbContext, LibraryDbContext>();
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:49201"));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });

            
        }
    }
}
