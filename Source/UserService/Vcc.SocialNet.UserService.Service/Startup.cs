using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;
using Vcc.SocialNet.UserService.Data;
using Vcc.SocialNet.UserService.Data.Repository;
using Vcc.SocialNet.UserService.Service.Execeptions;
using Vcc.SocialNet.UserService.Service.Filters;

namespace Vcc.SocialNet.Services.UserService
{
    public class Startup
    {
        private ILogger<Startup> _logger;
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opts =>
                    {
                        opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        opts.SerializerSettings.Converters.Add(new StringEnumConverter
                        {
                            CamelCaseText = true
                        });
                    });
            // Set up swagger generation
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0.0", new Info
                    {
                        Version = "1.0.0",
                        Title = "Vaughan Community Church Social Network",
                        Description = "Vaughan Community Church Social Network (ASP.NET Core 2.0)",
                        Contact = new Contact()
                        {
                            Name = "OpenAPI-Generator Contributors",
                            Url = "https://github.com/openapitools/openapi-generator",
                            Email = ""
                        },
                        TermsOfService = ""
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetEntryAssembly().GetName().Name}.xml");
                    // Sets the basePath property in the Swagger document generated
                    c.DocumentFilter<BasePathFilter>("/v1");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });

            services.AddDbContext<UserContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("UserDB"),  // specify connection string
                b => b.MigrationsAssembly("Vcc.SocialNet.UserService.Data"))); // need this line because Migration needs to be added to a seperate project
            services.AddTransient<IMemberRepository, EFMemberRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // centralized exception handling
            // ConfigureExceptionHandler method is an custom extension method leverging the built-in UseExceptionHandler middleware
            app.ConfigureExceptionHandler(_logger);
            app.UseMvc();
            //routes =>
            //{
            //    routes.MapRoute(
            //       name: "default",
            //       template: "{controller}/{action=Index}/{id?}");
            //});            
        }
    }
}
