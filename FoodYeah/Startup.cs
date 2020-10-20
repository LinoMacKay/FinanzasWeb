using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FoodYeah.Persistence;
using FoodYeah.Service;
using AutoMapper;
using FoodYeah.Service.Impl;
using FoodYeah.Model;
using FoodYeah.Model.Identity;
using Microsoft.AspNetCore.Identity;

namespace FoodYeah
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
            // Para conectarse con Postgre:
            //
            services.AddCors(options =>
            {
                options.AddPolicy("Cors",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  });
            });



            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(
               opts => opts.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );
            //Para la seguridad:
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //Para hacer la contraseña especial:
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
            // Para conectarse con SQL:
            //
            // services.AddDbContext<ApplicationDbContext>(
            //     opts => opts.UseSqlServer(Configuration.GetConnectionString("SQLConnection"))
            // );

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddTransient<CustomerService, CustomerServiceImpl>();
            services.AddTransient<ProductService, ProductServiceImpl>();
            services.AddTransient<OrderService, OrderServiceImpl>();
            services.AddTransient<CardService, CardServiceImpl>();            
            services.AddTransient<Product_CategoryService, Product_CategoryServiceImpl>();    
            services.AddTransient<Customer_CategoryService, Customer_CategoryServiceImpl>();  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("Cors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
