using Ambedo.Models;
using Ambedo.Models.Options;
using Ambedo.Repositories;
using Ambedo.Repositories.Interfaces;
using Ambedo.Services;
using Ambedo.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace Ambedo.API
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
            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings();
                settings.Converters.Add(new StringEnumConverter());
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                return settings;
            };
            services.AddControllers().AddNewtonsoftJson(cntx =>
            {
                cntx.SerializerSettings.Converters.Add(new StringEnumConverter());
                cntx.UseCamelCasing(true);
            });
            services.Configure<DatabaseOptions>(Configuration.GetSection(DatabaseOptions.KEY));
            var dbConfig = Configuration.GetSection(DatabaseOptions.KEY).Get<DatabaseOptions>();
            services.AddHealthChecks().AddMongoDb(dbConfig.ConnectionString.Replace("<password>", Configuration["Database:Password"]),
                                                  name: "database",
                                                  timeout: TimeSpan.FromSeconds(5),
                                                  tags: new []{ "ready" });
            services.AddSingleton<IDatabaseContext, DatabaseContext>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IThootlesService, ThootlesService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ambedo.API", Version = "v1" });
            });
            services.AddSwaggerGenNewtonsoftSupport();

            ConventionRegistry.Register("main", new ConventionPack { new CamelCaseElementNameConvention() }, (_) => true);
            BsonSerializer.RegisterSerializer(new EnumSerializer<ThootleCategories>(BsonType.String));
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ambedo.API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions { Predicate = (check) => check.Tags.Contains("ready") } );
                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = (_) => false });
            });
        }
    }
}
