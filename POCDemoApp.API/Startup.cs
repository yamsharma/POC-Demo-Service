using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POCDemoApp.Infrastructure.DataAccess.Context;
using POCDemoApp.Infrastructure.IoC;

namespace POCDemoApp.API
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
			// AutoMapper
			services.AddAutoMapper(typeof(Startup));

			// MediatR
			services.AddMediatR(typeof(Startup));

			// Controllers
			services.AddControllers();

			// DbContext
			services.AddDbContext<EdgeDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("EdgeDbConnection")));

			// CORS
			services.AddCors();

			// Swagger
			services.AddSwaggerGen(swaggerGenOptions =>
			{
				swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "POCDemoApp API", Version = "v1" });
			});

			// Dependency Injection
			RegisterServices(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			// CORS
			app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

			app.UseAuthorization();

			// Swagger
			app.UseSwagger();
			app.UseSwaggerUI(swaggerUiOptions =>
			{
				swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "POCDemoApp API V1");
			});

			// API Endpoints
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		private static void RegisterServices(IServiceCollection services)
		{
			DependencyContainer.RegisterServices(services);
		}
	}
}
