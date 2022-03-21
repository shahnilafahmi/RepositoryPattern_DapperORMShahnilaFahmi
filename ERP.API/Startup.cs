using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.API.Common;
using ERP.Data.DataRepository.HomeDataDapperRepository;
using ERP.Application.Repositories.HomeService;
using ERP.Data.DataRepository.SecurityDataDapperRepositor;
using ERP.Application.Repositories.SecuritySetupService;
using ERP.Data.DataRepository.SetupDataDapperRepository;
using ERP.Application.Repositories.SetupService;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace ERP.API
{
    public class Startup
    {
        private const string DefaultCorsPolicyName = "localhost";
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
               
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ERP.API", Version = "v1" });
              
            });

            services.AddSingleton<IConfiguration>(Configuration);
            Global.ConnectionString = Configuration.GetConnectionString("EmployeeDB");

            //services.AddScoped<IHomeService, HomeService>();

            //services.AddScoped<IHomeDataDapperService, HomeDataDapperRepository>();

            services.AddScoped<ISecuritySetupService, SecuritySetupService>();

            services.AddScoped<ISecurityDataDapperRepositor, SecurityDataDapperRepositor>();

            services.AddScoped<ISetupService, SetupService>();

            services.AddScoped<ISetupDataDapperRepository, SetupDataDapperRepository>();

            services.AddScoped<IHRMSSetupService, HRMSSetupService>();

            services.AddScoped<IHRMSDataDapperRepositor, HRMSDataDapperRepository>();

            services.AddScoped<ITMSSetupService, TMSSetupService>();

            services.AddScoped<ITMSDataDapperRepositor, TMSDataDapperRepository>();

            services.AddResponseCaching();

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            

            #region Cors

            string corsOriginsSettings = Configuration["App:CorsOrigins"];
            //Configure CORS for angular2 UI
            services.AddCors(options =>
            {
                //options.AddPolicy(DefaultCorsPolicyName, builder =>
                //{
                //    //App:CorsOrigins in appsettings.json can contain more than one address with splitted by comma.
                //    builder.AllowAnyOrigin()
                //        .AllowAnyHeader()
                //        .AllowAnyMethod()
                //        //.AllowCredentials()
                //        .SetPreflightMaxAge(TimeSpan.FromSeconds(10));

                //});
                options.AddPolicy("Security",
               builder => builder.WithOrigins("http://localhost", "http://localhost:3000" , "http://192.168.61.32:999").AllowAnyHeader().AllowAnyMethod()

               );
            });

            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "ERP.API v1");
                  // c.RoutePrefix = string.Empty;
                }
               );

                app.UseCors("Security");

            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseCors(DefaultCorsPolicyName); //Enable CORS!

            app.UseAuthorization();
            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Ui}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ui}/{action=Index}/{id?}"
                 
                    );

            });
        }
    }
}
