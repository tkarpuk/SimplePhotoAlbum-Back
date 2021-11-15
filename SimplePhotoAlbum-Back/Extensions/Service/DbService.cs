using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimplePhotoAlbum.DAL;

namespace SimplePhotoAlbum_Back.Extensions.Service
{
    public static class DbService
    {
        public static void AddDbServiceExt(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDb>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("SimplePhotoAlbum-Back"))
                );
        }
    }
}
