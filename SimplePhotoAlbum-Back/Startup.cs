using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimplePhotoAlbum.BLL;
using SimplePhotoAlbum_Back.Extensions.App;
using SimplePhotoAlbum_Back.Extensions.Service;

namespace SimplePhotoAlbum_Back
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<PhotoService>();

            services.AddFormConfigExt();
            services.AddCorsExt();
            services.AddSwaggerExt();
            services.AddAutomapperExt();
            services.AddAuthenticationExt();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
