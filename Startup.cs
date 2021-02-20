using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorJob.Areas.Identity;
using BlazorJob.Data;
using BlazorJob.Services;
using System.IO;
using System.Reflection;

namespace BlazorJob
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //------------------------------------------
            // Core

            //services.AddCors(options => not check
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost",
            //                                "https://localhost");
            //        });
            //});

            services
                //http://www.npgsql.org/efcore/
                .AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o =>
                {
                    //o.UseNodaTime();
                    o.SetPostgresVersion(9, 6);
                }
                ))
                .AddControllers()
                .AddNewtonsoftJson();//json patch
                //.ConfigureApiBehaviorOptions(options =>
                //{
                //    //options.SuppressConsumesConstraintForFormFileParameters = true;
                //    //options.SuppressInferBindingSourcesForParameters = true;
                //    //options.SuppressModelStateInvalidFilter = true;
                //    //options.SuppressMapClientErrors = true;
                //    //options.ClientErrorMapping[404].Link = "https://httpstatuses.com/404";
                //});

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlite(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAntDesign();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            //------------------------------------------
            // Nuget

            // Register the Swagger generator, defining 1 or more Swagger documents
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "API",
                        Version = "v1",
                    });


                    // Set the comments path for the Swagger JSON and UI.
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });

            //https://github.com/twenzel/WebOptimizer.Dotless
            //https://github.com/ligershark/WebOptimizer#install-and-setup
            services.AddWebOptimizer(pipeline =>
                {
                    //pipeline.CompileLessFiles();
                    pipeline.AddLessBundle("/css/style.css", "/css/style.less");//.UseFileProvider(;
                    //pipeline.CompileLessFiles();
                    //pipeline.CompileLessFiles("css/fix.less");
                });


            //------------------------------------------
            // Data

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<WeatherForecastService>();
            //services.AddSingleton<PostService>(x =>
            //{
            //    var s = x.GetService<ApplicationDbContext>();
            //    return new PostService(s);
            //});
            services.AddScoped<PostService>();
            services.AddScoped<OptionsService>();
            services.AddScoped<MetaService>();
            services.AddScoped<NodeRedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //https://docs.microsoft.com/ru-ru/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio#add-and-configure-swagger-middleware
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

                //set swagger page as index
                //c.RoutePrefix = string.Empty;
                c.RoutePrefix = "api";
            });

            app.UseWebOptimizer();//less files compile

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseCors();//not check

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                //endpoints.MapFallbackToAreaPage("/Admin/Pages/Index", "Admin");
                //endpoints.MapAreaControllerRoute("admin_route", "Admin", "Admin/{controller}/{action}/{id?}");
                endpoints.MapFallbackToPage("/_Host");

            });
        }
    }
}
