using AppBusiness.Impl;
using AppBusiness.Impl.Services;
using AppBusiness.Interface;
using AppBusiness.Interface.Interfaces;
using AppPersistence.Interface;
using AppPersistence.Interface.Interfaces;
using AppPersistence.MySql;
using AppPersistence.MySql.Repositories;
using AppPersistence.MySql.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi
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
            //string connString = Configuration.GetConnectionString("DefaultConn");

            services.AddControllers();

            //services.AddDbContextPool<AppDbContext>(option =>
            //{
            //    option.UseMySql(connString, ServerVersion.AutoDetect(connString));
            //});

            services.AddSingleton<IPersistence>(new Persistence());
            services.AddSingleton<IBusiness, Business>();


            services.AddSingleton<IObatService, ObatService>();
            services.AddSingleton<ITransaksiService, TransaksiService>();
            //services.AddScoped<IObat, ObatRepository>();
            //services.AddScoped<IObatService, ObatService>();

            services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(typeof(AutoMapperProfile));



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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
