using System;
using Microsoft.AspNetCore.Http;

namespace TaskManagement2023
{
	public class Startup
	{

		public void ConfigurationServices(IServiceCollection service)
		{

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Welcome to the Task Management App for 2023!");
				});
			});
		}
		
	}
}

