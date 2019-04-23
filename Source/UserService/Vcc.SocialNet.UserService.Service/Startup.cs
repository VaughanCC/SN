using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Vcc.SocialNet.UserService.Data;
using Vcc.SocialNet.UserService.Data.Repository;
using Vcc.SocialNet.UserService.Service.Configuration;
using Vcc.SocialNet.UserService.Service.Execeptions;
using Vcc.SocialNet.UserService.Service.Filters;

namespace Vcc.SocialNet.Services.UserService
{
    public class Startup
    {
        private ILogger<Startup> _logger;
        IConfigurationSection _securitySettingSection;
        private SecuritySettings _securitySettings;
        private string API_VERSION_HEADER = "api-version";
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;

            // register SecuritySettings section from config 
            _securitySettingSection = Configuration.GetSection("SecuritySettings");
            _securitySettings = _securitySettingSection.Get<SecuritySettings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // make security settings available for dependency injection on controller constructurs
            services.Configure<SecuritySettings>(_securitySettingSection);

            // configure Jwt Token authentication
            var secretKey = Encoding.ASCII.GetBytes(_securitySettings.AuthTokenSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAutoMapper();
            services.AddCors();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowMyOrigin",
            //                      builder => builder.WithOrigins("http://localhost"));
            //});
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opts =>
                    {
                        // change property names to start with a lower case
                        opts.UseMemberCasing();
                        //opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                        // converter for enum values
                        opts.SerializerSettings.Converters.Add(new StringEnumConverter
                        {
                            CamelCaseText = true
                        });
                    });
            // versioning using request header: we need to ensure to accept Headers for setting up CORS
            services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader(API_VERSION_HEADER));
                       
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

            // configure DbContext
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
            // allows the specific client host address to call APIs 
            // AllowAnyHeader is required to accept api-versioning
            app.UseCors(options =>
                options.WithOrigins(_securitySettings.AllowedOrigins.Split(';'))
                       .WithHeaders(_securitySettings.AllowedHeaders.Split(';')) 
                       .AllowAnyMethod());
        
            app.UseMvc();
            //routes =>
            //{
            //    routes.MapRoute(
            //       name: "default",
            //       template: "{controller}/{action=Index}/{id?}");
            //});            
        }

        //private string getHostEndPoint(IServiceCollection services)
        //{
        //    services.
        //    var features = app.Properties["server.Features"] as FeatureCollection;
        //    var addresses = features.Get<IServerAddressesFeature>();
        //    var address = addresses.Addresses.First();
        //    var uri = new Uri(address);
        //}
    }
}
