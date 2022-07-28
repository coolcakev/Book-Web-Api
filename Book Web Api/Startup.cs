using Book_Web_Api.Extension;
using Book_Web_Api.Managers;
using Book_Web_Api.Managers.Intrefaces;
using Bussiness_logic.Interfaces;
using Bussiness_logic.Services;
using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Domain.MappingProfile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Web_Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book_Web_Api", Version = "v1" });
            });
            services.AddSingleton<ILoggerManager, LoggerManager>();
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddCors(options =>
            {
                options.AddPolicy(name: "default",
                                  policy =>
                                  {
                                      policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                                  });
            });
            services.AddDbContext<ApplicationContext>(options =>
              options.UseSqlServer(connection));

            services.AddAutoMapper(typeof(BookProfile));
            services.AddAutoMapper(typeof(ReviewProfile));
            services.AddAutoMapper(typeof(RatingProfile));

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IRewievService, RewievService>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<IRewievRepository, RewievRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book_Web_Api v1"));
            }
         
            app.UseExeptionHandle();
            app.UseLogging();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("default");
            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
