using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vcc.Security.IDService.Data;

namespace Vcc.Security.IDService
{
    public class Startup
    {
        const string connectionString =
            @"Data Source=(LocalDb)\MSSQLLocalDB;database=Test.IdentityServer4.EntityFramework;trusted_connection=yes;";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddOperationalStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)))
                .AddConfigurationStore(options =>
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(migrationsAssembly)));
                //.AddAspNetIdentity<ApplicationUser>();

            services.AddMvc();

            // IdentityServer4 change: Configure to use Identity Server
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddTestUsers(Config.GetUsers())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryClients(Config.GetClients());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // initialize daabase 
            //InitializeDbTestData(app);
            
            // IdentityServer4 change: Configure to use Identity Server
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }

        //private static void InitializeDbTestData(IApplicationBuilder app)
        //{
        //    using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //    {
        //        scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
        //        scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
        //        scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();

        //        var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

        //        if (!context.Clients.Any())
        //        {
        //            foreach (var client in Clients.Get())
        //            {
        //                context.Clients.Add(client.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        if (!context.IdentityResources.Any())
        //        {
        //            foreach (var resource in Resources.GetIdentityResources())
        //            {
        //                context.IdentityResources.Add(resource.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        if (!context.ApiResources.Any())
        //        {
        //            foreach (var resource in Resources.GetApiResources())
        //            {
        //                context.ApiResources.Add(resource.ToEntity());
        //            }
        //            context.SaveChanges();
        //        }

        //        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        //        if (!userManager.Users.Any())
        //        {
        //            foreach (var testUser in Users.Get())
        //            {
        //                var identityUser = new IdentityUser(testUser.Username)
        //                {
        //                    Id = testUser.SubjectId
        //                };

        //                userManager.CreateAsync(identityUser, "Password123!").Wait();
        //                userManager.AddClaimsAsync(identityUser, testUser.Claims.ToList()).Wait();
        //            }
        //        }
        //    }
        //}
    }
}
