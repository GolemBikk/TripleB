using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ViewModels;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace BadBoysBoating
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });

            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(
        opts =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("ru-RU"),
                new CultureInfo("en-US")
            };

            opts.DefaultRequestCulture = new RequestCulture("ru-RU");
            // Formatting numbers, dates, etc.
            opts.SupportedCultures = supportedCultures;
            // UI strings that we have localized.
            opts.SupportedUICultures = supportedCultures;
        });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {



            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies",
                LoginPath = new PathString("/Account/LoginAccount"),
                LogoutPath = new PathString("/Account/Logout"),
                AccessDeniedPath = new PathString("/Home/Index"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DatabaseInitialization();
        }



        /// <summary>
        /// Инициализации БД
        /// </summary>
        private void DatabaseInitialization()
        {
            RegisterViewModel
            admin2 = new RegisterViewModel
            {
                UserLogin = "varian",
                Password = "87654321",
                UserName = "Michael Velichko",
                Email = "varian913@gmail.com",
                AccountType = "admin"
            },
            admin1 = new RegisterViewModel
            {
                UserLogin = "chiron",
                Password = "12345678",
                UserName = "Alexander Iundin",
                Email = "dorian.adret@gmail.com",
                AccountType = "admin"
            },
            user1 = new RegisterViewModel
            {
                UserLogin = "user1",
                Password = "12345678",
                UserName = "Ivan Ivanov",
                Email = "petrov1996@gmail.com",
                AccountType = "client"
            },
            user2 = new RegisterViewModel
            {
                UserLogin = "user2",
                Password = "12345678",
                UserName = "Peter Petrov",
                Email = "ivanov2808@gmail.com",
                AccountType = "customer"
            };
            AuthorizationService service = new AuthorizationService();
            service.RegisterNewAccount(admin1);
            service.RegisterNewAccount(admin2);
            service.RegisterNewAccount(user1);
            service.RegisterNewAccount(user2);
        }
    }
}
