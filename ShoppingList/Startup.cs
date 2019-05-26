using AspNetCore.RouteAnalyzer;
using Hellang.Middleware.SpaFallback;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NJsonSchema;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.Processors;
using ShoppingList.DBContext;
using ShoppingList.Services;
using ShoppingList.Services.Class;
using ShoppingList.Services.Interface;
using System.Reflection;

namespace ShoppingList
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
            services.AddSpaFallback();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(
                    json => json.SerializerSettings.ReferenceLoopHandling
                            = ReferenceLoopHandling.Ignore);
           
           /* services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                options.ReportApiVersions = true;
            });*/
            services.AddRouteAnalyzer();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
            var connection = @"Server=tcp:shoppinglistv2dbserver.database.windows.net,1433;Initial Catalog=ShopdddpingDatabases;Persist Security Info=False;User ID=gszasza1;Password=GEMAszasza1997;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<ShoppingListContext>
                (options => options.UseSqlServer(connection));
            services.AddTransient<IBuyListInterface, BuyListService>();
            services.AddTransient<IFoodInterface, FoodService>();
            services.AddTransient<IFoodCounterInterface, FoodCounterService>();
            services.AddTransient<IRatingMessageInterface, RatingMessageService>();
            services.AddSwaggerDocument();
            
        }
        //Server=tcp:shoppinglistv2dbserver.database.windows.net,1433;Initial Catalog=ShopdddpingDatabases;Persist Security Info=False;User ID={gszasza1};Password={GEMAszasza1997};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        //Server=(localdb)\mssqllocaldb;Database=ShoppingDatabase;Trusted_Connection=True;ConnectRetryCount=0;MultipleActiveResultSets = True
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSpaFallback();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseSwagger();
            
            app.UseSwaggerUi3();
            app.UseMvc(routes =>
            {
                routes.MapRouteAnalyzer("/routes");
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
         
        }
    }
}
