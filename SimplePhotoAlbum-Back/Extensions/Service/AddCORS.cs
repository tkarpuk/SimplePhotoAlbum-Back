using Microsoft.Extensions.DependencyInjection;

namespace SimplePhotoAlbum_Back.Extensions.Service
{
    public static class AddCORS
    {
        public static void AddCorsExt(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options =>
                options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }
    }
}
