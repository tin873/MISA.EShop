using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MISA.Eshop.Core.Interfaces.IRepository;
using MISA.Eshop.Core.Interfaces.IService;
using MISA.Eshop.Core.Service;
using MISA.Eshop.Infrastructure.Repository;

namespace MISA.Eshop.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.Eshop.API", Version = "v1" });
            });

            services.AddCors(options => 
            options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
            );

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IWardService, WardService>();
            services.AddScoped<IWardRepository, WardRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.Eshop.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
