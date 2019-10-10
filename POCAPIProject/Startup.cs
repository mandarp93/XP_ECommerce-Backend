using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Interfaces;
using DALLayer;
using DALLayer.CustomerEntities;
using DALLayer.DataRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace POCAPIProject
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DBModel>(Options => Options.UseSqlServer(Configuration.GetConnectionString("MyConnString")));
            services.AddScoped<ICutomerDAL, CustomerDAL>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<IProductDAL, ProductDAL>();
            services.AddScoped<ICartBL, CartBL>();
            services.AddScoped<ICartDAL, CartDAL>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IOrderDAL, OrderDAL>();
            services.AddScoped<ICategoryBL, CategoryBL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
           
        }
    }
}
