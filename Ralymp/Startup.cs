using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ralymp.DataAccessLayer;
using Ralymp.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Ralymp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: Temp fix for CORS
            services.AddCors(CorsPolicySetup);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "RalympClient/build"; });

            ConfigureDi(services, Configuration);

            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", new Info {Title = "Testing API doc", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //TODO: Temp fix for CORS
            app.UseCors("CorsPolicy");

            //TODO: For testing in case of exceptions
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment() == false)
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseSpaStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(configuration =>
            {
                configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "Testing API doc");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "RalympClient";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer("start");
                }
            });
        }

        private static void CorsPolicySetup(CorsOptions options)
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        }

        private static void ConfigureDi(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("ralymp-data");
            services.AddDbContext<RalympDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IStudentProfileService, StudentProfileService>();
        }
    }
}