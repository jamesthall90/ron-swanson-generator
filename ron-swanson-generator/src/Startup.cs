using Autofac;
using System;
using System.Reflection;
using AutoMapper;
using DataAccess;
using Infrastructure;
using Infrastructure.Interfaces.ReadModel;
using Infrastructure.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models;
using Read;
using Write;

namespace ron_swanson_generator
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
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.DescribeStringEnumsInCamelCase();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "HTTP API",
                    Version = "v1",
                    Description = "The Service HTTP API"
                });
            });
            
//            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            const string connectionString = "User ID=postgres; Password=Password1; Host=localhost; Port=5432; Database=swanson;";
            
            services.AddEntityFrameworkNpgsql().AddDbContext<RonSwansonContext>(
                options => options.UseNpgsql(connectionString, m => m.MigrationsAssembly("DataAccess")), ServiceLifetime.Transient);

            services.AddCors(options =>
            {
                options.AddPolicy("Policy",
                    builder => builder
                        .WithHeaders("accept", "content-type", "origin", "x-custom-header")
                        .WithOrigins("http://localhost:8080")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
                        .Build()
                );
            });

            services.AddMvc();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            app.UseSwagger()
                .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "HTTP API V1"); });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region Automapper Registrations
            
            builder.Register(a => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperModelProfile());
            })).AsSelf().SingleInstance();
            
            builder.Register(a => a.Resolve<MapperConfiguration>()
                    .CreateMapper(a.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
            
            #endregion

            #region Project Autofac Module Registrations
            
            builder.RegisterModule<DataAccessAutofacModule>();
            builder.RegisterModule<InfrastructureAutofacModule>();
            builder.RegisterModule<ReadModelAutofacModule>();
            builder.RegisterModule<WriteModelAutofacModule>();

            #endregion
        }
        
    }
}