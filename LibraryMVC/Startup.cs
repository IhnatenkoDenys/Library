using AutoMapper;
using LibraryDataAccess;
using LibraryDataAccess.Entities;
using LibraryDataAccess.Interfaces;
using LibraryDataAccess.Repositories;
using LibraryServices.Interfaces;
using LibraryServices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMVC
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(connection)
            );

            AddDALRepositories(services);
            AddBusinessLogicServices(services);

            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddSwaggerGen();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void AddBusinessLogicServices(IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IPublisherService, PublisherService>();
        }

        private void AddDALRepositories(IServiceCollection services)
        {
            services.AddScoped<IAsyncRepository<Author>, AuthorRepository>();
            services.AddScoped<IAsyncRepository<Book>, BookRepository>();
            services.AddScoped<IAsyncRepository<Country>, EfRepository<Country>>();
            services.AddScoped<IAsyncRepository<Publisher>, EfRepository<Publisher>>();
        }
    }
}
