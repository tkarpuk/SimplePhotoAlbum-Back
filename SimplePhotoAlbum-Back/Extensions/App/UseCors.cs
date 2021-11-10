using Microsoft.AspNetCore.Builder;

namespace SimplePhotoAlbum_Back.Extensions.App
{
    public static class UseCors
    {
        public static void UseCorsExt(this IApplicationBuilder app, string policyName)
        {
            app.UseCors(policyName);
        }
    }
}
