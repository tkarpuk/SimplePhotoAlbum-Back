using Microsoft.Extensions.DependencyInjection;

namespace SimplePhotoAlbum_Back.Extensions.Service
{
    public static class AddAutoMapper
    {
        public static void AddAutomapperExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
