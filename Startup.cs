using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using peopleAPI.Models;
using peopleAPI.Services;
using photosAPI.Models;
using photosAPI.Services;

namespace photosAPI
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
            // requires using Microsoft.Extensions.Options
            services.Configure<PhotosDatabaseSettings>(
                Configuration.GetSection(nameof(PhotosDatabaseSettings)));

            services.AddSingleton<IPhotosDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PhotosDatabaseSettings>>().Value);
            services.AddSingleton<PhotosService>();

            services.Configure<PeopleDatabaseSettings>(
            Configuration.GetSection(nameof(PeopleDatabaseSettings)));

            services.AddSingleton<IPeopleDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PeopleDatabaseSettings>>().Value);
            services.AddSingleton<PeopleService>();

            services.AddControllers();
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
