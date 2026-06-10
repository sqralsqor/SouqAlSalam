using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SouqAlSalam.API.Controllers;

namespace SouqAlSalam.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

       

        // دالة ربط المشروع بقاعدة البيانات
        public void ConfigureServices(IServiceCollection services)
        {          
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title ="SouqAlSalam API",
                    Version = "v1"
                });
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

                services.AddMvc()
                .AddApplicationPart(typeof(AuthController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SouqAlSalam API v1"); });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseCors("AllowAll");
            
        }
    }
}
