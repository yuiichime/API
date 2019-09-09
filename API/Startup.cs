using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Base;
using Infrastructure.Context;
using Infrastructure.CrossCutting.Helpers;
using Infrastructure.Data.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOptions();
            services.Configure<MvcOptions>(x =>
            {
            });
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddSwaggerDocument();

            var mapping = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingEntity());
                x.AddProfile(new MappingDTO());
            });
            IMapper mapper = mapping.CreateMapper();

            services.AddSingleton(mapper);
            /////Repositories
            services.AddScoped<IRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            services.AddScoped<UserRepository>();


            /////Services
            services.AddScoped<UserService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
