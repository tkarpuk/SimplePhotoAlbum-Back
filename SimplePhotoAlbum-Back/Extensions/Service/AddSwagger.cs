using Microsoft.Extensions.DependencyInjection;

namespace SimplePhotoAlbum_Back.Extensions.Service
{
    public static class AddSwagger
    {
        public static void AddSwaggerExt(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
