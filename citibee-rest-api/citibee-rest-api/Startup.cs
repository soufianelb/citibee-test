﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper;
using citibee_rest_api.Dal;
using citibee_rest_api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace citibee_rest_api
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
            //entityframework gebruikmakend van dependency injection
            services.AddDbContext<CitibeeContext>(options => 
               options.UseNpgsql("Host=localhost;Database=citibee;Username=postgres;Password=postgres")
            );
            //wordt gebruikt voor het mappen van model naar dto objecten
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<GebruikerService>();
            services.AddScoped<ParkeergarageService>();
            services.AddScoped<GereserveerditemService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //dit zou weg moeten voor security redenen. dit is nu een quick fix omdat nu security van de api niet belangrijk is
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
            app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { ShowStatusCode = true });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
