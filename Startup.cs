
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using OrionTM_Web.Services;
using ReflectionIT.Mvc.Paging;
using System;
using System.Globalization;

namespace OrionTM_Web;

public class Startup
{


    private static readonly List<CultureInfo> _supoetedCultures = new List<CultureInfo>
    {
       
        new CultureInfo("pt-BR"),
        new CultureInfo("es"),
         new CultureInfo("en"),

    };


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        //var connectionString = Configuration["dbContextSettings:ConnectionString"];
        //services.AddDbContext<AppDbContext>(options =>
        //   options.UseNpgsql(connectionString)
        //);


        services.AddIdentity<IdentityUser,IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        //codig para politica de senha
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true; 
            options.Password.RequireUppercase=true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 1;
        });


       
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", politica =>
            {
                politica.RequireRole("Admin");

            });
        });

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


        services.AddLocalization(opt => opt.ResourcesPath = "Recources");
        services.AddControllersWithViews().AddViewLocalization(opt => opt.ResourcesPath = "Resources");

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("pt-BR", "pt-BR");
            options.SupportedCultures = _supoetedCultures;
            options.SupportedUICultures = _supoetedCultures;

        });


        services.AddControllersWithViews(); 

        services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

      
        services.AddMemoryCache();
        services.AddSession();

       


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


        app.UseHttpsRedirection();

        var options = app
            .ApplicationServices
            .GetService<IOptions<RequestLocalizationOptions>>()
            .Value;

        app.UseRequestLocalization();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();    
        app.UseAuthorization();
        app.UseSession();
        seedUserRoleInitial.SeedRoles();
        seedUserRoleInitial.SeedUsers();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
               name: "categoriaFiltro",
               pattern: "Lanche/{action}/{categoria?}",
               defaults: new { controller = "Lanche", Action = "List" });


        endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

         });



    }

}