﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Swashbuckle.AspNetCore.Swagger;
using TaskManagerApi.Business;
using TaskManagerApi.Business.Interface;
using TaskManagerApi.Data;
using TaskManagerApi.Data.Interface;

namespace TaskManagerApi
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
            services.AddDbContext<TaskManagerDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("TaskManagerDatabase")));

            services.AddScoped<IRepository<Model.Task>, TaskRepository>();
            services.AddScoped<IRepository<Model.ParentTask>, ParentTaskRepository>();
            services.AddScoped<IService<Model.Task>, TaskService>();
            services.AddScoped<IService<Model.ParentTask>, ParentTaskService>();

            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "TaskManager", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => {
                    swaggerDoc.Host = "dev.taskmanager.com:501";
                    swaggerDoc.Schemes = new List<string>() { httpReq.Scheme };
                });
            });
            app.UseSwaggerUI(c => {
                c.DisplayOperationId();
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "TaskManager Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowCredentials();
            });
            app.UseMvc();
        }
    }
}
