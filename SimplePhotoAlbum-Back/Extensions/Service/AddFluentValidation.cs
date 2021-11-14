using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimplePhotoAlbum_Back.Extensions.Service
{
    public static class AddFluentValidation
    {
        public static void AddFluentValidationExt(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
        }
    }
}
