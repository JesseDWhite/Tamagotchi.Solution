using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.StaticFiles;

namespace Tamagotchi
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseRouting();

      app.UseEndpoints(routes =>
      {
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
      app.UseStaticFiles();
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
      });
    }
  }
}

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// namespace Tamagotchi
// {
//   public class Startup
//   {
//     public Startup(IConfiguration configuration)
//     {
//       Configuration = configuration;
//     }

//     public IConfiguration Configuration { get; }

//     public void ConfigureServices(IServiceCollection services)
//     {
//       services.AddControllersWithViews();
//     }


//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//       if (env.IsDevelopment())
//       {
//         app.UseDeveloperExceptionPage();
//       }
//       else
//       {
//         app.UseExceptionHandler("/Home/Error");
//         app.UseHsts();
//       }
//       app.UseHttpsRedirection();
//       app.UseStaticFiles();

//       app.UseRouting();

//       app.UseAuthorization();

//       app.UseEndpoints(endpoints =>
//       {
//         endpoints.MapControllerRoute(
//                   name: "default",
//                   pattern: "{controller=Home}/{action=Index}/{id?}");
//       });
//     }
//   }
// }