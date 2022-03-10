using Communicator.ApiServer.Hubs;
using Communicator.Application;
using Communicator.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Communicator.ApiServer
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
            services.AddControllers()
            .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            #region Add Infrastructure

            services.AddInfrastructure(Configuration);

            #endregion Add Infrastructure

            #region Add Application

            services.AddApplication();

            #endregion Add Application

            services.AddCors(o => o.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                 .AllowCredentials()
                 .WithOrigins("http://localhost:4200");
            }));

            services.AddSignalR().AddJsonProtocol(opt => { opt.PayloadSerializerOptions.PropertyNamingPolicy = null; });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Communicator.ApiServer", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
               endpoints.MapHub<MessangerHub>("/MessangerHub");
             
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Communicator.ApiServer v1"));
        }
    }
}