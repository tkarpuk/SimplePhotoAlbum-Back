using Microsoft.AspNetCore.Builder;

namespace SimplePhotoAlbum_Back.Extensions.App
{
    public static class UseSwagger
    {
        public static void UseSwaggerExt(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
