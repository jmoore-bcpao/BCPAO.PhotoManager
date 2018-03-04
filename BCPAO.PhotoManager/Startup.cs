using BCPAO.PhotoManager.Data;
using BCPAO.PhotoManager.Data.Entities;
using BCPAO.PhotoManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BCPAO.PhotoManager
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		private readonly IHostingEnvironment _hostingEnv;

		public Startup(IConfiguration configuration, IHostingEnvironment hostingEnv)
		{
			Configuration = configuration;
			_hostingEnv = hostingEnv;
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DatabaseContext>(options =>
				 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<User, Role>()
				 .AddEntityFrameworkStores<DatabaseContext>()
				 .AddUserStore<UserStore<User, Role, DatabaseContext, int>>()
				 .AddRoleStore<RoleStore<Role, DatabaseContext, int>>()
				 .AddDefaultTokenProviders();

			// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?tabs=visual-studio%2Caspnetcore2x
			services.Configure<IdentityOptions>(options =>
			{
				// Password settings
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = false;
				options.Password.RequiredUniqueChars = 6;

				// Lockout settings
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
				options.Lockout.MaxFailedAccessAttempts = 10;
				options.Lockout.AllowedForNewUsers = true;

				// User settings
				options.User.RequireUniqueEmail = true;
			});

			services.ConfigureApplicationCookie(options =>
			{
				// Cookie settings
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
				options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
				options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
				options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
				options.SlidingExpiration = true;
			});

			// Add application services.
			services.AddTransient<IEmailSender, EmailSender>();
			services.AddScoped<IPhotoRepository, PhotoRepository>();

			// Requires all authentication on all controllers. Use [AllowAnonymous] for anonymous access.
			services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			});
			
			var skipSSL = Configuration.GetValue<bool>("LocalTest:skipSSL");
			services.Configure<MvcOptions>(options =>
			{
				if (_hostingEnv.IsDevelopment() && !skipSSL)
				{
					options.Filters.Add(new RequireHttpsAttribute());
				}
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseAuthentication();
			
			app.UseMvc(routes =>
			{
				routes.MapRoute(
						 name: "default",
						 template: "{controller=Home}/{action=Index}/{id?}");
			});

			var defaultAdminPwd = Configuration["defaultAdminPwd"];
			
			//try
			//{
			//	SeedData.Initialize(app.ApplicationServices, defaultAdminPwd).Wait();
			//}
			//catch (Exception)
			//{
			//	throw;
			//}

			//using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			//{
			//	if (!serviceScope.ServiceProvider.GetService<DatabaseContext>().AllMigrationsApplied())
			//	{
			//		serviceScope.ServiceProvider.GetService<DatabaseContext>().Database.Migrate();
			//		serviceScope.ServiceProvider.GetService<DatabaseContext>().EnsureSeeded();
			//	}
			//}
		}
	}
}
