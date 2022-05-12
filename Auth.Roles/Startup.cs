using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Roles
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Cookie")
                .AddCookie("Cookie", conf =>
                {
                    conf.LoginPath = "/Admin/Login";
                    conf.AccessDeniedPath = "/Home/AccessDenide";
                });

            // here we add policy and roles as a claims
            services.AddAuthorization(conf =>
            {
                conf.AddPolicy("Administrator", builder =>
                {
                    builder.RequireRole(ClaimTypes.Role, "Administrator");
                });

                //conf.AddPolicy("Manager", builder =>
                //{
                //    builder.RequireClaim(ClaimTypes.Role, "Manager");
                //});

                // this policy contain two Role claim and useful for controlers which has attribute Policy="Multiple"
                conf.AddPolicy("Multiple", builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role,"Manager") ||
                    x.User.HasClaim(ClaimTypes.Role,"Administrator")
                    );
                });

            });




            services.AddControllersWithViews();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
