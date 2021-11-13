using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SimplePhotoAlbum_Back.Authorization
{
    public class AuthOptions
    {
        public const string ISSUER = "SimplePhotoAlbumAPP"; // издатель токена
        public const string AUDIENCE = "NoNameAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!(ha-ha)x3"; 
        public const int LIFETIME = 20; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
