using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWeatherAPI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions =>
            {
                cookieOptions.LoginPath = "/";
            });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/admin");
                options.Conventions.AddPageRoute("/admin/index", "");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            });

            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddHttpClient("metaweather", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("MetaAPI"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
