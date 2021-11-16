using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimplePhotoAlbum.BLL;
using SimplePhotoAlbum.DAL;
using SimplePhotoAlbum_Back.Extensions.App;
using SimplePhotoAlbum_Back.Extensions.Service;

namespace SimplePhotoAlbum_Back
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<PhotoService>();
            services.AddTransient<UnitOfWork>();

            services.AddDbServiceExt(_configuration.GetConnectionString("DefaultConnection"));
            services.AddFormConfigExt();
            services.AddCorsExt();
            services.AddSwaggerExt();
            services.AddAutomapperExt();
            services.AddAuthenticationExt();
            services.AddFluentValidationExt();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler(logger);
            app.UseSwaggerExt();

            app.UseRouting();
            app.UseCorsExt("AllowOrigin");

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
